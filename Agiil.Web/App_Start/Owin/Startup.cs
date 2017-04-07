using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Owin.Security.AesDataProtectorProvider;

[assembly: OwinStartup(typeof(Agiil.Web.App_Start.Owin.Startup))]

namespace Agiil.Web.App_Start.Owin
{
  /// <summary>
  /// Implementation of an OWIN startup configuration type.  Must be named <c>Startup</c> and must have a
  /// <c>Configuration</c> method.
  /// </summary>
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      var config = new HttpConfiguration();

      new OwinDependencyInjectionConfig().Configure(app, config);
      new WebApiConfig().Register(config);

      app.UseAutofacMvc();

      app.UseAutofacWebApi(config);
      app.UseWebApi(config);

      ConfigureBearerTokenAuthentication(app, config);
      ConfigureHttpAuthentication(app);
    }

    private void ConfigureHttpAuthentication(IAppBuilder builder)
    {
      builder.UseCookieAuthentication(new CookieAuthenticationOptions {
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        LoginPath = new PathString($"/Login"),
      });

      builder.UseAesDataProtectorProvider();

      builder.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
    }

    private void ConfigureBearerTokenAuthentication(IAppBuilder builder, HttpConfiguration config)
    {
      builder.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
      {
        AuthenticationMode = AuthenticationMode.Active,
        AllowedAudiences = new[] { "Any" },
        IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[] {
          new SymmetricKeyIssuerSecurityTokenProvider("Agiil", "c2VjcmV0Cg=="),
        },
      });

      var options = DependencyResolver.Current.GetService(typeof(OAuthAuthorizationServerOptions));
      builder.UseOAuthAuthorizationServer((OAuthAuthorizationServerOptions) options);

      builder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
    }
  }
}
