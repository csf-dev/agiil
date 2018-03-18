using System;
using NUnit.Framework;
using Agiil.Auth;
using Ploeh.AutoFixture.NUnit3;
using Moq;
using Agiil.Web.Controllers;
using System.Web.Mvc;
using Agiil.Domain.Auth;
using Agiil.Web.Models.Auth;
using Agiil.Tests.Attributes;
using Agiil.Web.Services.Auth;

namespace Agiil.Tests.Web.Controllers
{
  [TestFixture,Parallelizable]
  public class LoginControllerTests
  {
    [Test, AutoMoqData]
    public void Index_returns_view_using_existing_model(LoginResult loginResult,
                                                        [NoAutoProperties] LoginController sut)
    {
      // Arrange
      sut.TempData.Add(LoginController.LoginResultKey, loginResult);

      // Act
      var result = sut.Index(null);

      // Assert
      Assert.IsInstanceOf<ViewResult>(result, "Result is a view");
      var model = ((ViewResult) result).Model;
      Assert.IsInstanceOf<LoginModel>(model, "Model is expected type");
      var loginModel = (LoginModel) model;
      Assert.AreEqual(loginResult, loginModel.Result, "Model contains expected value");
    }

    [Test, AutoMoqData]
    public void Login_uses_login_logout_manager_service([Frozen] ILoginLogoutManager loginLogoutManager,
                                                        Agiil.Web.Models.Auth.LoginCredentials credentials,
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
                                                                          Agiil.Web.Models.Auth.LoginCredentials credentials,
                                                                          string username,
                                                                          [NoAutoProperties] LoginController sut)
    {
      // Arrange
      Mock.Get(loginLogoutManager)
          .Setup(x => x.AttemptLogin(It.IsAny<ILoginRequest>()))
          .Returns(new LoginResult(username));
      credentials.ReturnUrl = null;

      // Act
      var result = sut.Login(credentials);

      // Assert
      Assert.IsInstanceOf<RedirectToRouteResult>(result, "Result is a redirect-to-route");
      var redirect = (RedirectToRouteResult) result;
      Assert.AreEqual("Login", redirect.RouteValues["controller"], "Correct controller");
      Assert.AreEqual(nameof(LoginController.Index), redirect.RouteValues["action"], "Correct action");
    }

    [Test, AutoMoqData]
    public void Login_redirects_to_return_url_after_successful_login([Frozen] ILoginLogoutManager loginLogoutManager,
                                                                     [Frozen] IValidatesRedirectUrls redirectValidator,
                                                                     Agiil.Web.Models.Auth.LoginCredentials credentials,
                                                                     string username,
                                                                     [NoAutoProperties] LoginController sut)
    {
      // Arrange
      Mock.Get(loginLogoutManager)
          .Setup(x => x.AttemptLogin(It.IsAny<ILoginRequest>()))
          .Returns(new LoginResult(username));
      credentials.ReturnUrl = "/Sample/Url";
      Mock.Get(redirectValidator)
          .Setup(x => x.IsValid(It.IsAny<string>()))
          .Returns(true);

      // Act
      var result = sut.Login(credentials);

      // Assert
      Assert.IsInstanceOf<RedirectResult>(result, "Result is a redirect-to-URL");
      var redirect = (RedirectResult) result;
      Assert.AreEqual("/Sample/Url", redirect.Url, "Correct URL");
      Assert.IsFalse(redirect.Permanent, "Non-permanent redirect");
    }

    [Test, AutoMoqData]
    public void Login_ignores_return_url_if_it_is_not_valid([Frozen] ILoginLogoutManager loginLogoutManager,
                                                            [Frozen] IValidatesRedirectUrls redirectValidator,
                                                            Agiil.Web.Models.Auth.LoginCredentials credentials,
                                                            string username,
                                                            [NoAutoProperties] LoginController sut)
    {
      // Arrange
      Mock.Get(loginLogoutManager)
          .Setup(x => x.AttemptLogin(It.IsAny<ILoginRequest>()))
          .Returns(new LoginResult(username));
      credentials.ReturnUrl = "/Sample/Url";
      Mock.Get(redirectValidator)
          .Setup(x => x.IsValid(It.IsAny<string>()))
          .Returns(false);

      // Act
      var result = sut.Login(credentials);

      // Assert
      Assert.IsInstanceOf<RedirectToRouteResult>(result, "Result is a redirect-to-URL");
      var redirect = (RedirectToRouteResult) result;
      Assert.AreEqual("Login", redirect.RouteValues["controller"], "Correct controller");
      Assert.AreEqual(nameof(LoginController.Index), redirect.RouteValues["action"], "Correct action");
    }

    [Test, AutoMoqData]
    public void Login_redirects_to_login_page_after_failed_login([Frozen] ILoginLogoutManager loginLogoutManager,
                                                                 Agiil.Web.Models.Auth.LoginCredentials credentials,
                                                                 [NoAutoProperties] LoginController sut)
    {
      // Arrange
      Mock.Get(loginLogoutManager)
          .Setup(x => x.AttemptLogin(It.IsAny<ILoginRequest>()))
          .Returns(LoginResult.LoginFailed);
      credentials.ReturnUrl = null;

      // Act
      var result = sut.Login(credentials);

      // Assert
      Assert.IsInstanceOf<RedirectToRouteResult>(result, "Result is a redirect-to-route");
      var redirect = (RedirectToRouteResult) result;
      Assert.AreEqual("Login", redirect.RouteValues["controller"], "Correct controller");
      Assert.AreEqual(nameof(LoginController.Index), redirect.RouteValues["action"], "Correct action");
    }

    [Test, AutoMoqData]
    public void Login_ignores_return_url_on_failed_login([Frozen] ILoginLogoutManager loginLogoutManager,
                                                         Agiil.Web.Models.Auth.LoginCredentials credentials,
                                                         [NoAutoProperties] LoginController sut)
    {
      // Arrange
      Mock.Get(loginLogoutManager)
          .Setup(x => x.AttemptLogin(It.IsAny<ILoginRequest>()))
          .Returns(LoginResult.LoginFailed);
      credentials.ReturnUrl = "/Sample/Url";

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
  }
}
