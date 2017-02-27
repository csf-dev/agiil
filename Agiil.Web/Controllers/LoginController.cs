using System;
using System.Web.Mvc;
using CSF.IssueTracker.Auth;
using CSF.IssueTracker.Web.Models;

namespace CSF.IssueTracker.Web.Controllers
{
  public class LoginController : Controller
  {
    #region constants

    internal const string LoginRouteName = "";

    #endregion

    #region fields

    readonly LoginRequestCreator loginRequestCreator;
    readonly ILoginLogoutManager loginLogoutManager;

    #endregion

    #region controller actions

    [AllowAnonymous]
    [HttpGet]
    [Route(LoginRouteName)]
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
    [Route(LoginRouteName)]
    public ActionResult ProcessLogin(string username, string password)
    {
      var loginRequest = loginRequestCreator(username, password);
      var result = loginLogoutManager.AttemptLogin(loginRequest);

      if(result.Success)
      {
        return RedirectToRoute(new {
          controller = typeof(HomeController).Name,
          action = nameof(HomeController.Index)
        });
      }

      return RedirectToRoute(new {
        controller = typeof(LoginController).Name,
        action = nameof(LoginController.Index),
        result
      });
    }

    [AllowAnonymous]
    [HttpPost]
    public ActionResult LogOut()
    {
      var result = loginLogoutManager.AttemptLogout();

      if(result.Success)
      {
        return RedirectToRoute(new {
          controller = typeof(LoginController),
          action = nameof(LoginController.LoggedOut),
        });
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
