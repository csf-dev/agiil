using System;
using System.Security.Claims;
using System.Threading;
using System.Linq;
using CSF.Entities;
using Agiil.Domain.Auth;
using Agiil.Services.Auth;

namespace Agiil.Auth
{
  public class ClaimsIdentityReader : IIdentityReader
  {
    readonly IPrincipalGetter principalGetter;

    protected IPrincipalGetter PrincipalGetter => principalGetter;

    public virtual ICurrentUserInfo GetCurrentUserInfo()
    {
      var principal = GetPrincipal();

      if(principal == null)
      {
        return null;
      }

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
      return PrincipalGetter.GetCurrentPrincipal();
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

    public ClaimsIdentityReader(IPrincipalGetter principalGetter)
    {
      if(principalGetter == null)
        throw new ArgumentNullException(nameof(principalGetter));

      this.principalGetter = principalGetter;
    }
  }
}
