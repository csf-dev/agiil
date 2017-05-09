using System;
using NUnit.Framework;
using Agiil.Auth;
using Ploeh.AutoFixture.NUnit3;
using Moq;
using Agiil.Web.Controllers;
using System.Web.Mvc;
using Agiil.Web.Models;
using Agiil.Domain.Auth;

namespace Agiil.Tests.Web.Controllers
{
  [TestFixture]
  public class LoginControllerTests
  {
    #region tests

    [Test, AutoMoqData]
    public void Index_returns_view_using_existing_model(LoginResult loginResult,
                                                        [NoAutoProperties] LoginController sut)
    {
      // Arrange
      sut.TempData.Add(LoginController.LoginResultKey, loginResult);

      // Act
      var result = sut.Index();

      // Assert
      Assert.IsInstanceOf<ViewResult>(result, "Result is a view");
      var model = ((ViewResult) result).Model;
      Assert.IsInstanceOf<LoginModel>(model, "Model is expected type");
      var loginModel = (LoginModel) model;
      Assert.AreEqual(loginResult, loginModel.Result, "Model contains expected value");
    }

    [Test, AutoMoqData]
    public void Login_uses_login_logout_manager_service([Frozen] ILoginLogoutManager loginLogoutManager,
                                                        Agiil.Web.Models.LoginCredentials credentials,
                                                        [NoAutoProperties] LoginController sut)
    {
      // Arrange
      Mock.Get(loginLogoutManager)
          .Setup(x => x.AttemptLogin(It.IsAny<ILoginRequest>()))
          .Returns(LoginResult.LoginFailed);

      // Act
      sut.Login(credentials);

      // Assert
      Mock.Get(loginLogoutManager).Verify(x => x.AttemptLogin(It.IsAny<ILoginRequest>()), Times.Once());
    }

    [Test, AutoMoqData]
    public void Login_redirects_to_home_controller_after_successful_login([Frozen] ILoginLogoutManager loginLogoutManager,
                                                                          Agiil.Web.Models.LoginCredentials credentials,
                                                                          string username,
                                                                          [NoAutoProperties] LoginController sut)
    {
      // Arrange
      Mock.Get(loginLogoutManager)
          .Setup(x => x.AttemptLogin(It.IsAny<ILoginRequest>()))
          .Returns(new LoginResult(username));

      // Act
      var result = sut.Login(credentials);

      // Assert
      Assert.IsInstanceOf<RedirectToRouteResult>(result, "Result is a redirect-to-route");
      var redirect = (RedirectToRouteResult) result;
      Assert.AreEqual("Login", redirect.RouteValues["controller"], "Correct controller");
      Assert.AreEqual(nameof(LoginController.Index), redirect.RouteValues["action"], "Correct action");
    }

    [Test, AutoMoqData]
    public void Login_redirects_to_login_page_after_failed_login([Frozen] ILoginLogoutManager loginLogoutManager,
                                                                 Agiil.Web.Models.LoginCredentials credentials,
                                                                 [NoAutoProperties] LoginController sut)
    {
      // Arrange
      Mock.Get(loginLogoutManager)
          .Setup(x => x.AttemptLogin(It.IsAny<ILoginRequest>()))
          .Returns(LoginResult.LoginFailed);

      // Act
      var result = sut.Login(credentials);

      // Assert
      Assert.IsInstanceOf<RedirectToRouteResult>(result, "Result is a redirect-to-route");
      var redirect = (RedirectToRouteResult) result;
      Assert.AreEqual("Login", redirect.RouteValues["controller"], "Correct controller");
      Assert.AreEqual(nameof(LoginController.Index), redirect.RouteValues["action"], "Correct action");
    }

    [Test, AutoMoqData]
    public void Logout_uses_login_logout_manager_service([Frozen] ILoginLogoutManager loginLogoutManager,
                                                         [NoAutoProperties] LoginController sut)
    {
      // Arrange
      Mock.Get(loginLogoutManager)
          .Setup(x => x.AttemptLogout())
          .Returns(LogoutResult.LogoutSuccessful);

      // Act
      sut.Logout();

      // Assert
      Mock.Get(loginLogoutManager).Verify(x => x.AttemptLogout(), Times.Once());
    }

    [Test, AutoMoqData]
    public void Logout_redirects_to_logged_out_page_on_successful_logout([Frozen] ILoginLogoutManager loginLogoutManager,
                                                                         [NoAutoProperties] LoginController sut)
    {
      // Arrange
      Mock.Get(loginLogoutManager)
          .Setup(x => x.AttemptLogout())
          .Returns(LogoutResult.LogoutSuccessful);

      // Act
      var result = sut.Logout();

      // Assert
      Assert.IsInstanceOf<RedirectToRouteResult>(result, "Result is a redirect-to-route");
      var redirect = (RedirectToRouteResult) result;
      Assert.AreEqual("Login", redirect.RouteValues["controller"], "Correct controller");
      Assert.AreEqual(nameof(LoginController.LoggedOut), redirect.RouteValues["action"], "Correct action");
    }

    #endregion
  }
}
