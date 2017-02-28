using System;
using System.Security.Claims;
using System.Threading;
using System.Linq;
using CSF.Entities;
using Agiil.Domain.Auth;

namespace Agiil.Auth
{
  public class ClaimsIdentityReader : IIdentityReader
  {
    public ICurrentUserInfo GetCurrentUserInfo()
    {
      var principal = GetPrincipal();

      var username = GetClaim(ClaimTypes.NameIdentifier, principal);
      var identityValue = GetClaim(CustomClaimTypes.UserNumericId, principal);

      var identity = CreateIdentity(identityValue);

      return new UserInformation(identity, username);
    }

    ClaimsPrincipal GetPrincipal()
    {
      return Thread.CurrentPrincipal as ClaimsPrincipal;
    }

    string GetClaim(string claimType, ClaimsPrincipal principal)
    {
      return principal.Claims.Single(x => x.Type == claimType).Value;
    }

    IIdentity<User> CreateIdentity(string identityValue)
    {
      var val = long.Parse(identityValue);
      return Identity.Create<User>(val);
    }
  }
}
