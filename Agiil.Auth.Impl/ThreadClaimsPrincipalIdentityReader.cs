using System;
using System.Security.Claims;
using System.Threading;
using System.Linq;
using CSF.Entities;
using Agiil.Domain.Auth;

namespace Agiil.Auth
{
  public class ThreadClaimsPrincipalIdentityReader : IIdentityReader
  {
    public virtual ICurrentUserInfo GetCurrentUserInfo()
    {
      var principal = GetPrincipal();

      var username = GetClaim(ClaimTypes.NameIdentifier, principal);
      var identityValue = GetClaim(CustomClaimTypes.UserNumericId, principal);

      if(identityValue == null)
      {
        return null;
      }

      var identity = CreateIdentity(identityValue);

      return new UserInformation(identity, username);
    }

    protected virtual ClaimsPrincipal GetPrincipal()
    {
      return Thread.CurrentPrincipal as ClaimsPrincipal;
    }

    protected virtual string GetClaim(string claimType, ClaimsPrincipal principal)
    {
      return principal.Claims.SingleOrDefault(x => x.Type == claimType)?.Value;
    }

    protected virtual IIdentity<User> CreateIdentity(string identityValue)
    {
      var val = long.Parse(identityValue);
      return Identity.Create<User>(val);
    }
  }
}
