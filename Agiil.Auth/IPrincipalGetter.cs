using System;
using System.Security.Claims;

namespace Agiil.Auth
{
  public interface IPrincipalGetter
  {
    ClaimsPrincipal GetCurrentPrincipal();
  }
}
