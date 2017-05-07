using System;
using System.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;

namespace Agiil.Web.OAuth
{
  public class JwtBearerAuthenticationOptionsFactory : IJwtBearerAuthenticationOptionsFactory
  {
    const string JwtAllowedAudiences = "Agiil";

    readonly IOAuthConfiguration oauthConfig;

    public JwtBearerAuthenticationOptions GetOptions()
    {
      return new JwtBearerAuthenticationOptions
      {
        AuthenticationMode = AuthenticationMode.Active,
        AllowedAudiences = new[] { JwtAllowedAudiences },
        IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[] {
          new SymmetricKeyIssuerSecurityTokenProvider(oauthConfig.JwtIssuerName, oauthConfig.Base64JwtSecretKey),
        },
        TokenHandler = new JwtSecurityTokenHandler
        {
          SignatureProviderFactory = new MonoCompatibleSignatureProviderFactory(),
        },
      };
    }

    public JwtBearerAuthenticationOptionsFactory(IOAuthConfiguration oauthConfig)
    {
      if(oauthConfig == null)
        throw new ArgumentNullException(nameof(oauthConfig));
      
      this.oauthConfig = oauthConfig;
    }
  }
}
