using System;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace Agiil.Web.OAuth
{
  public class OAuthOptionsFactory
  {
    readonly OAuthAuthorizationProvider provider;
    readonly IOAuthConfiguration options;
    readonly OAuthJwtFormat format;
    readonly IOAuthPathProvider pathProvider;

    public OAuthAuthorizationServerOptions GetOptions()
    {
      var oauthOptions = new OAuthAuthorizationServerOptions {
        TokenEndpointPath = new PathString(pathProvider.GetTokenPath()),
        AccessTokenExpireTimeSpan = options.GetAccessTokenExpiryLifetime(),
        Provider = provider,
        AccessTokenFormat = format,
        AuthenticationMode = AuthenticationMode.Active,
      };

      #if DEBUG
      oauthOptions.AllowInsecureHttp = true;
      #endif

      return oauthOptions;
    }

    public OAuthOptionsFactory(OAuthAuthorizationProvider provider,
                               IOAuthConfiguration options,
                               OAuthJwtFormat format,
                               IOAuthPathProvider pathProvider)
    {
      if(pathProvider == null)
        throw new ArgumentNullException(nameof(pathProvider));
      if(format == null)
        throw new ArgumentNullException(nameof(format));
      if(options == null)
        throw new ArgumentNullException(nameof(options));
      if(provider == null)
        throw new ArgumentNullException(nameof(provider));
      
      this.provider = provider;
      this.options = options;
      this.format = format;
      this.pathProvider = pathProvider;
    }
  }
}
