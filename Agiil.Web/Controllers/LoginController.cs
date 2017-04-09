using System;
using System.Web.Mvc;
using Agiil.Auth;
using Agiil.Domain.Auth;
using Agiil.Web.Models;

namespace Agiil.Web.Controllers
{
  public class LoginController : ControllerBase
  {
    #region constants

    public static readonly string
      LoginResultKey = "LoginResult",
      CredentialsKey = "Credentials";

    #endregion

    #region fields

    readonly LoginRequestCreator loginRequestCreator;
    readonly ILoginLogoutManager loginLogoutManager;
    readonly IIdentityReader identityReader;

    #endregion

    #region controller actions

    [AllowAnonymous]
    [HttpGet]
    public ActionResult Index()
    {
      var model = GetLoginModel();
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

      TempData.Add(LoginResultKey, result);
      TempData.Add(CredentialsKey, credentials);

      return RedirectToAction(nameof(LoginController.Index), GetControllerName<LoginController>());
    }

    [AllowAnonymous]
    [HttpPost]
    public ActionResult Logout()
    {
      var result = loginLogoutManager.AttemptLogout();

      if(!result.Success)
      {
        throw new NotImplementedException("Failure to log out is not supported.");
      }

      return RedirectToAction(nameof(LoginController.LoggedOut), GetControllerName<LoginController>());
    }

    LoginModel GetLoginModel()
    {
      var currentUser = identityReader.GetCurrentUserInfo();
      var result = GetTempData<LoginResult>(LoginResultKey);
      var credentials = GetTempData<Models.LoginCredentials>(CredentialsKey);

      return new LoginModel(result, currentUser, credentials);
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
