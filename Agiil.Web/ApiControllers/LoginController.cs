using System;
using System.Web.Http;
using Agiil.Auth;
using Agiil.Web.Models;

namespace Agiil.Web.ApiControllers
{
  public class LoginController : ApiController
  {
    #region fields

    readonly LoginRequestCreator loginRequestCreator;
    readonly ILoginLogoutManager loginLogoutManager;

    #endregion

    #region API methods

    [AllowAnonymous]
    [HttpPost]
    public LoginResult Login(Models.LoginCredentials credentials)
    {
      var loginRequest = loginRequestCreator(credentials.Username, credentials.Password);
      return loginLogoutManager.AttemptLogin(loginRequest);
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
