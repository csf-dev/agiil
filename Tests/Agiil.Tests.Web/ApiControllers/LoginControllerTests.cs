using System;
using NUnit.Framework;
using Agiil.Tests.Common;
using Agiil.Auth;
using Moq;
using Agiil.Web.ApiControllers;
using Agiil.Web.Models;

namespace Agiil.Tests.Web.ApiControllers
{
  [TestFixture]
  public class LoginControllerTests
  {
    #region tests

    [Test, AutoMoqData]
    public void Login_uses_login_logout_manager_service(ILoginLogoutManager loginLogoutManager,
                                                        ILoginRequest request,
                                                        Agiil.Web.Models.LoginCredentials credentials)
    {
      // Arrange
      LoginRequestCreator requestCreator = (u, p) => request;
      Mock.Get(loginLogoutManager)
          .Setup(x => x.AttemptLogin(It.IsAny<ILoginRequest>()))
          .Returns(LoginResult.LoginFailed);
      var sut = new LoginController(requestCreator, loginLogoutManager);

      // Act
      sut.Login(credentials);

      // Assert
      Mock.Get(loginLogoutManager).Verify(x => x.AttemptLogin(request), Times.Once());
    }

    [Test, AutoMoqData]
    public void Login_returns_loginresult_from_service(ILoginLogoutManager loginLogoutManager,
                                                       ILoginRequest request,
                                                       Agiil.Web.Models.LoginCredentials credentials,
                                                       LoginResult loginResult)
    {
      // Arrange
      LoginRequestCreator requestCreator = (u, p) => request;
      Mock.Get(loginLogoutManager)
          .Setup(x => x.AttemptLogin(It.IsAny<ILoginRequest>()))
          .Returns(loginResult);
      var sut = new LoginController(requestCreator, loginLogoutManager);

      // Act
      var result = sut.Login(credentials);

      // Assert
      Assert.AreSame(loginResult, result);
    }

    #endregion
  }
}
