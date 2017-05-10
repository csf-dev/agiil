using System;
using System.Web.Mvc;
using Agiil.Auth;
using Agiil.Domain.Auth;
using Agiil.Web.Models;

namespace Agiil.Web.Controllers
{
  [AllowAnonymous]
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

    [HttpGet]
    public ActionResult Index(string returnUrl)
    {
      var model = GetLoginModel();
      model.ReturnUrl = returnUrl;
      return View(model);
    }

    [HttpGet]
    public ActionResult LoggedOut()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Login(Models.LoginCredentials credentials)
    {
      var loginRequest = loginRequestCreator(credentials.Username, credentials.Password);
      var result = loginLogoutManager.AttemptLogin(loginRequest);

      TempData.Add(LoginResultKey, result);
      TempData.Add(CredentialsKey, credentials);

      if(result.Success && !String.IsNullOrEmpty(credentials.ReturnUrl))
      {
        // TODO: IMO I should sanitise this URL before we blindly redirect
        // Otherwise an attacker could hand out links with malicious URLs in them
        return Redirect(credentials.ReturnUrl);
      }

      return RedirectToAction(nameof(LoginController.Index), GetControllerName<LoginController>());
    }

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
