using System;
using System.IdentityModel.Tokens;
using System.Security.Cryptography;
using Agiil.Web.Services.Config;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;

namespace Agiil.Web.Services.Auth
{
  public class OAuthJwtFormat : ISecureDataFormat<AuthenticationTicket>
  {
    readonly IOAuthConfiguration config;

    public OAuthJwtFormat(IOAuthConfiguration config)
    {
      if(config == null)
        throw new ArgumentNullException(nameof(config));

      this.config = config;
    }

    public string Protect(AuthenticationTicket data)
    {
      if(data == null)
        throw new ArgumentNullException(nameof(data));

      var issued = data.Properties.IssuedUtc;
      var expires = data.Properties.ExpiresUtc;

      var base64Key = config.Base64JwtSecretKey;
      var key = Convert.FromBase64String(base64Key);

      var signingCredentials = new SigningCredentials(new CustomInMemorySymmetricSecurityKey(key),
                                                      SecurityAlgorithms.HmacSha256Signature,
                                                      SecurityAlgorithms.Sha256Digest);

      var token = new JwtSecurityToken(issuer: config.JwtIssuerName,
                                       audience: config.JwtIssuerName,
                                       claims: data.Identity.Claims,
                                       notBefore: issued.Value.UtcDateTime,
                                       expires: expires.Value.UtcDateTime,
                                       signingCredentials: signingCredentials);

      var handler = new JwtSecurityTokenHandler();

      var jwt = handler.WriteToken(token);

      return jwt;
    }

    public AuthenticationTicket Unprotect(string protectedText)
    {
      throw new NotSupportedException();
    }
  }
}
