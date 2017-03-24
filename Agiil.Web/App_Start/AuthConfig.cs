using System;
using System.Threading.Tasks;
using Agiil.Domain.Auth;
using Agiil.Web.Services.Auth;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Owin.Security.AesDataProtectorProvider;

namespace Agiil.Web.App_Start
{
  public class AuthConfig
  {
    public void Configure(IAppBuilder builder)
    {
      ConfigureHttpAuthentication(builder);

      ConfigureApiAuthentication(builder);
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

    private void ConfigureApiAuthentication(IAppBuilder builder)
    {
      var oauthOptions = new OAuthAuthorizationServerOptions {
        TokenEndpointPath = new PathString("/oauth2/token"),
        AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
        Provider = new OAuthAuthorizationProvider(),
      };

      //#if DEBUG
      oauthOptions.AllowInsecureHttp = true;
      //#endif

      builder.UseOAuthAuthorizationServer(oauthOptions);

      builder.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
      {
        AuthenticationMode = AuthenticationMode.Active,
        AllowedAudiences = new[] { "Any" },
        IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[] {
          new SymmetricKeyIssuerSecurityTokenProvider("Agiil", "c2VjcmV0Cg=="),
        }
      });
    }
  }
}
