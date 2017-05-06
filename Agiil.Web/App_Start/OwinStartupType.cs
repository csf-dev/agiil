using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Agiil.Web.Bootstrap;
using Agiil.Web.Services.Auth;
using Agiil.Web.Services.Config;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Owin.Security.AesDataProtectorProvider;

[assembly: OwinStartup(typeof(Agiil.Web.App_Start.OwinStartupType))]

namespace Agiil.Web.App_Start
{
  /// <summary>
  /// Implementation of an OWIN startup configuration type.  Must be named <c>Startup</c> and must have a
  /// <c>Configuration</c> method.
  /// </summary>
  public class OwinStartupType
  {
    const string JwtAllowedAudiences = "Agiil";

    public void Configuration(IAppBuilder app)
    {
      var config = new HttpConfiguration();

      var container = ConfigureDependencyInjection(app, config);

      app.UseAutofacMvc();

      new RouteConfiguration().RegisterWebApiRoutes(config);
      app.UseAutofacWebApi(config);
      app.UseWebApi(config);

      ConfigureBearerTokenAuthentication(app, container);
      ConfigureHttpAuthentication(app);
    }

    private IContainer ConfigureDependencyInjection(IAppBuilder app, HttpConfiguration config)
    {
      var diConfig = new WebAppDiConfiguration(config, true);
      var container = diConfig.GetContainerBuilder().Build();

      var provider = new OwinCompatibleLifetimeScopeProvider(container);

      DependencyResolver.SetResolver(new AutofacDependencyResolver(container, provider));
      config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

      return container;
    }

    private void ConfigureHttpAuthentication(IAppBuilder builder)
    {
      builder.UseCookieAuthentication(new CookieAuthenticationOptions {
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        LoginPath = new PathString(RouteConfiguration.GetMvcLoginPath()),
      });

      builder.UseAesDataProtectorProvider();

      builder.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
    }

    private void ConfigureBearerTokenAuthentication(IAppBuilder builder, IContainer container)
    {
      var oauthConfig = container.Resolve<IOAuthConfiguration>();

      builder.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
      {
        AuthenticationMode = AuthenticationMode.Active,
        AllowedAudiences = new[] { JwtAllowedAudiences },
        IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[] {
          new SymmetricKeyIssuerSecurityTokenProvider(oauthConfig.JwtIssuerName, oauthConfig.Base64JwtSecretKey),
        },
        TokenHandler = new JwtSecurityTokenHandler
        {
          SignatureProviderFactory = new CustomSignatureProviderFactory(),
        },
        Provider = new OAuthBearerAuthenticationProvider
        {
          OnValidateIdentity = ctx => {
            Thread.CurrentPrincipal = new ClaimsPrincipal(ctx.Ticket.Identity);
            return Task.FromResult<object>(null);
          }
        },
      });

      var authServerOptions = container.Resolve<OAuthAuthorizationServerOptions>();
      builder.UseOAuthAuthorizationServer(authServerOptions);

      builder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
    }

    class CustomSignatureProviderFactory : SignatureProviderFactory
    {
      public override SignatureProvider CreateForVerifying(SecurityKey key, string algorithm)
      {
        if(algorithm == SecurityAlgorithms.HmacSha256Signature && key is InMemorySymmetricSecurityKey)
        {
          var castKey = (InMemorySymmetricSecurityKey) key;
          var copiedKey = new CustomInMemorySymmetricSecurityKey(castKey.GetSymmetricKey());
          return new SymmetricSignatureProvider(copiedKey, algorithm);
        }

        return base.CreateForVerifying(key, algorithm);
      }
    }
  }
}
