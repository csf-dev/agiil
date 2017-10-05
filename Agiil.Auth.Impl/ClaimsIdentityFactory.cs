using System;
using System.Security.Claims;
using CSF.Entities;

namespace Agiil.Auth
{
  public class ClaimsIdentityFactory : IClaimsIdentityFactory
  {
    public ClaimsIdentity GetIdentity(IAuthenticationResult result, string authenticationType)
    {
      if(result == null)
        throw new ArgumentNullException(nameof(result));
      if(!result.Success)
        throw new ArgumentException("Authentication result must indicate success.", nameof(result));

      return GetIdentity(result.Username, result.UserIdentity, authenticationType);
    }

    public ClaimsIdentity GetIdentity(string username, IIdentity userIdentity, string authenticationType)
    {
      if(username == null)
        throw new ArgumentNullException(nameof(username));
      
      var claims = new [] {
        new Claim(ClaimTypes.NameIdentifier, username),
        new Claim(CustomClaimTypes.UserNumericId, userIdentity?.Value?.ToString()),
      };
      return new ClaimsIdentity(claims, authenticationType);
    }
  }
}
