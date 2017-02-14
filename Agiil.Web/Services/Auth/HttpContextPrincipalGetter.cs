using System;
using System.Security.Claims;
using System.Web;
using Agiil.Auth;

namespace Agiil.Web.Services.Auth
{
  public class HttpContextPrincipalGetter : IPrincipalGetter
  {
    public ClaimsPrincipal GetCurrentPrincipal()
    {
      return HttpContext.Current?.User as ClaimsPrincipal;
    }
  }
}
