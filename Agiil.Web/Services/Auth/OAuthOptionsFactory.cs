using System;
using Agiil.Web.App_Start;
using Agiil.Web.Services.Config;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;

namespace Agiil.Web.Services.Auth
{
  public class OAuthOptionsFactory
  {
    readonly OAuthAuthorizationProvider provider;
    readonly IOAuthConfiguration options;

    public OAuthAuthorizationServerOptions GetOptions()
    {
      var oauthOptions = new OAuthAuthorizationServerOptions {
        TokenEndpointPath = new PathString(RouteConfiguration.OAuthTokenPath),
        AccessTokenExpireTimeSpan = options.GetAccessTokenExpiryLifetime(),
        Provider = provider,
      };

      #if DEBUG
      oauthOptions.AllowInsecureHttp = true;
      #endif

      return oauthOptions;
    }

    public OAuthOptionsFactory(OAuthAuthorizationProvider provider, IOAuthConfiguration options)
    {
      if(options == null)
        throw new ArgumentNullException(nameof(options));
      if(provider == null)
        throw new ArgumentNullException(nameof(provider));
      
      this.provider = provider;
      this.options = options;
    }
  }
}
