using System;
using System.Security.Claims;
using System.Threading;
using System.Linq;
using CSF.Entities;
using CSF.IssueTracker.Domain.Auth;

namespace CSF.IssueTracker.Auth
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

    private ClaimsPrincipal GetPrincipal()
    {
      return Thread.CurrentPrincipal as ClaimsPrincipal;
    }

    private string GetClaim(string claimType, ClaimsPrincipal principal)
    {
      return principal.Claims.Single(x => x.Type == claimType).Value;
    }

    private IIdentity<User> CreateIdentity(string identityValue)
    {
      var val = Int64.Parse(identityValue);
      return Identity.Create<User>(val);
    }
  }
}
