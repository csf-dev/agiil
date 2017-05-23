using System;
using System.Security.Claims;
using System.Threading;
using System.Web;
using Agiil.Auth;

namespace Agiil.Web.Services.Auth
{
  public class HttpContextPrincipalGetter : IPrincipalGetter
  {
    public ClaimsPrincipal GetCurrentPrincipal()
    {
      var httpContextUser = HttpContext.Current?.User as ClaimsPrincipal;

      if(httpContextUser != null)
      {
        return httpContextUser;
      }

      var threadUser = Thread.CurrentPrincipal as ClaimsPrincipal;
      return threadUser;
    }
  }
}
