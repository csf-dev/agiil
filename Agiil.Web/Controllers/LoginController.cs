using System;
using System.Web.Mvc;
using Agiil.Auth;
using Agiil.Web.Models;

namespace Agiil.Web.Controllers
{
  public class LoginController : ControllerBase
  {
    #region fields

    readonly LoginRequestCreator loginRequestCreator;
    readonly ILoginLogoutManager loginLogoutManager;
    readonly IIdentityReader identityReader;

    #endregion

    #region controller actions

    [AllowAnonymous]
    [HttpGet]
    public ActionResult Index(LoginResult result)
    {
      var currentUser = identityReader.GetCurrentUserInfo();
      var model = new LoginModel(result, currentUser);
      return View(model);
    }

    [AllowAnonymous]
    [HttpGet]
    public ActionResult LoggedOut()
    {
      return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public ActionResult Login(Models.LoginCredentials credentials)
    {
      var loginRequest = loginRequestCreator(credentials.Username, credentials.Password);
      var result = loginLogoutManager.AttemptLogin(loginRequest);

      if(result.Success)
      {
        return RedirectToAction(nameof(LoginController.Index), GetControllerName<LoginController>(), result);
      }

      return RedirectToAction(nameof(LoginController.Index), GetControllerName<LoginController>(), result);
    }

    [AllowAnonymous]
    [HttpPost]
    public ActionResult Logout()
    {
      var result = loginLogoutManager.AttemptLogout();

      if(result.Success)
      {
        return RedirectToAction(nameof(LoginController.LoggedOut), GetControllerName<LoginController>());
      }

      throw new NotImplementedException("Failure to log out is not supported.");
    }


    #endregion

    #region constructor

    public LoginController(LoginRequestCreator loginRequestCreator,
                           ILoginLogoutManager loginLogoutManager,
                           IIdentityReader identityReader)
    {
      if(identityReader == null)
        throw new ArgumentNullException(nameof(identityReader));
      if(loginLogoutManager == null)
        throw new ArgumentNullException(nameof(loginLogoutManager));
      if(loginRequestCreator == null)
        throw new ArgumentNullException(nameof(loginRequestCreator));

      this.loginRequestCreator = loginRequestCreator;
      this.loginLogoutManager = loginLogoutManager;
      this.identityReader = identityReader;
    }

    #endregion
  }
}
