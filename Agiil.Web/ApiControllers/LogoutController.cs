using System;
using System.Web.Http;
using Agiil.Auth;

namespace Agiil.Web.ApiControllers
{
  public class LogoutController : ApiController
  {
    #region fields

    readonly ILoginLogoutManager loginLogoutManager;

    #endregion

    #region API methods

    [AllowAnonymous]
    [HttpPost]
    public void Logout()
    {
      var result = loginLogoutManager.AttemptLogout();

      if(!result.Success)
      {
        throw new NotImplementedException("Failure to log out is not supported.");
      }
    }

    #endregion

    #region constructor

    public LogoutController(ILoginLogoutManager loginLogoutManager)
    {
      if(loginLogoutManager == null)
        throw new ArgumentNullException(nameof(loginLogoutManager));

      this.loginLogoutManager = loginLogoutManager;
    }

    #endregion
  }
}
