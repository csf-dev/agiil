using System;
using System.Security.Claims;

namespace Agiil.Auth
{
  public class ClaimsIdentityFactory : IClaimsIdentityFactory
  {
    public ClaimsIdentity GetIdentity(IAuthenticationResult result, string authenticationType)
    {
      if(result == null)
      {
        throw new ArgumentNullException(nameof(result));
      }
      if(!result.Success)
      {
        throw new ArgumentException("Authentication result must indicate success.", nameof(result));
      }

      var claims = new [] {
        new Claim(ClaimTypes.NameIdentifier, result.Username),
        new Claim(CustomClaimTypes.UserNumericId, result.UserIdentity?.Value?.ToString()),
      };
      return new ClaimsIdentity(claims, authenticationType);
    }
  }
}
