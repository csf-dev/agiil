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
      var model = ModelFactory.GetModel<LoginModel>();
      model.Result = GetTempData<LoginResult>(LoginResultKey);
      model.EnteredCredentials = GetTempData<Models.LoginCredentials>(CredentialsKey);
      return model;
    }

    #endregion

    #region constructor

    public LoginController(LoginRequestCreator loginRequestCreator,
                           ILoginLogoutManager loginLogoutManager,
                           Services.SharedModel.StandardPageModelFactory modelFactory)
      : base(modelFactory)
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
