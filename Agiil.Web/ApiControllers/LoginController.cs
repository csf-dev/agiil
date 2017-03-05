using System;
using System.Web.Http;
using Agiil.Auth;

namespace Agiil.Web.ApiControllers
{
  public class LoginController : ApiController
  {
    #region constants

    internal const string LoginRouteName = "";

    #endregion

    #region fields

    readonly LoginRequestCreator loginRequestCreator;
    readonly ILoginLogoutManager loginLogoutManager;

    #endregion

    #region API methods

    [AllowAnonymous]
    [HttpPost]
    [Route(LoginRouteName)]
    public LoginResult Login(string username, string password)
    {
      var loginRequest = loginRequestCreator(username, password);
      return loginLogoutManager.AttemptLogin(loginRequest);
    }

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

    public LoginController(LoginRequestCreator loginRequestCreator,
                           ILoginLogoutManager loginLogoutManager)
    {
      if(loginLogoutManager == null)
        throw new ArgumentNullException(nameof(loginLogoutManager));
      if(loginRequestCreator == null)
        throw new ArgumentNullException(nameof(loginRequestCreator));

      this.loginRequestCreator = loginRequestCreator;
      this.loginLogoutManager = loginLogoutManager;
    }

    #endregion
  }
}
