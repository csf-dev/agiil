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

    #endregion

    #region controller actions

    [AllowAnonymous]
    [HttpGet]
    public ActionResult Index(LoginResult result)
    {
      var model = new LoginModel(result);
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
    public ActionResult Login(string username, string password)
    {
      var loginRequest = loginRequestCreator(username, password);
      var result = loginLogoutManager.AttemptLogin(loginRequest);

      if(result.Success)
      {
        return RedirectToAction(nameof(HomeController.Index), GetControllerName<HomeController>());
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
