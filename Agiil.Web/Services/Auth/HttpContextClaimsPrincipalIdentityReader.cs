using System;
using System.Security.Claims;
using System.Web;
using Agiil.Auth;

namespace Agiil.Web.Services.Auth
{
  public class HttpContextClaimsPrincipalIdentityReader : ThreadClaimsPrincipalIdentityReader
  {
    protected override ClaimsPrincipal GetPrincipal()
    {
      var context = HttpContext.Current;
      return context?.User as ClaimsPrincipal;
    }
  }
}
