using System;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
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

      ConfigureOAuthServer(app, container);
      ConfigureWebApi(app, container);
      ConfigureWebApp(app, container);
    }

    void ConfigureOAuthServer(IAppBuilder app, IContainer container)
    {
      app.MapWhen(IsOAuthUrl, inner => {
        var authServerOptions = container.Resolve<OAuthAuthorizationServerOptions>();
        inner.UseOAuthAuthorizationServer(authServerOptions);
      });
    }

    void ConfigureWebApi(IAppBuilder app, IContainer container)
    {
      app.MapWhen(IsWebApiUrl, inner => {
        var config = new HttpConfiguration();

        config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        ConfigureBearerTokenAuthentication(inner, container);

        config.Filters.Add(new HostAuthenticationFilter(OAuthAuthorizationChecker.JwtBearerTokenAuthenticationType));

        config.Routes.Clear();
        new RouteConfiguration().RegisterWebApiRoutes(config);
        inner.UseAutofacWebApi(config);
        inner.UseWebApi(config);
      });
    }

    void ConfigureWebApp(IAppBuilder app, IContainer container)
    {
      app.MapWhen(IsWebAppUrl, inner => {
        new RouteConfiguration().RegisterMvcRoutes (RouteTable.Routes);
        new MvcViewConfiguration().RegisterViewEngines(ViewEngines.Engines);
        ConfigureCookieAuthentication(inner);
        inner.UseAutofacMvc();
      });
    }

    bool IsOAuthUrl(IOwinContext context)
    {
      if(context.Request.Uri.LocalPath.StartsWith(RouteConfiguration.OAuthPrefix, StringComparison.InvariantCulture))
        return true;

      return false;
    }

    bool IsWebApiUrl(IOwinContext context)
    {
      if(context.Request.Uri.LocalPath.StartsWith("/" + RouteConfiguration.ApiPrefix, StringComparison.InvariantCulture))
        return true;
      
      return false;
    }

    bool IsWebAppUrl(IOwinContext context)
    {
      return !(IsOAuthUrl(context) || IsWebApiUrl(context));
    }

    private IContainer ConfigureDependencyInjection(IAppBuilder app, HttpConfiguration config)
    {
      var diConfig = new WebAppDiConfiguration(config, true);
      var container = diConfig.GetContainerBuilder().Build();

      var provider = new OwinCompatibleLifetimeScopeProvider(container);

      DependencyResolver.SetResolver(new AutofacDependencyResolver(container, provider));

      return container;
    }

    private void ConfigureCookieAuthentication(IAppBuilder builder)
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
      });

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
