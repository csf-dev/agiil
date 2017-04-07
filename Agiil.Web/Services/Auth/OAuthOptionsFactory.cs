using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;

namespace Agiil.Web.Services.Auth
{
  public class OAuthOptionsFactory
  {
    readonly OAuthAuthorizationProvider provider;

    public OAuthAuthorizationServerOptions GetOptions()
    {
      var oauthOptions = new OAuthAuthorizationServerOptions {
        TokenEndpointPath = new PathString("/oauth2/token"),
        AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
        Provider = provider,

      };

      //#if DEBUG
      oauthOptions.AllowInsecureHttp = true;
      //#endif

      return oauthOptions;
    }

    public OAuthOptionsFactory(OAuthAuthorizationProvider provider)
    {
      if(provider == null)
      {
        throw new ArgumentNullException(nameof(provider));
      }

      this.provider = provider;
    }
  }
}
