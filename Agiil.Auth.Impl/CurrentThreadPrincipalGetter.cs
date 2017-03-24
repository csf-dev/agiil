using System;
using System.Security.Claims;
using System.Threading;

namespace Agiil.Auth
{
  public class CurrentThreadPrincipalGetter : IPrincipalGetter
  {
    public ClaimsPrincipal GetCurrentPrincipal()
    {
      return Thread.CurrentPrincipal as ClaimsPrincipal;
    }
  }
}
