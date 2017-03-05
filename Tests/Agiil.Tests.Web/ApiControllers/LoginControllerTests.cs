using System;
using NUnit.Framework;
using Agiil.Tests.Common;
using Agiil.Auth;
using Moq;
using Agiil.Web.ApiControllers;

namespace Agiil.Tests.Web.ApiControllers
{
  [TestFixture]
  public class LoginControllerTests
  {
    #region tests

    [Test, AutoMoqData]
    public void Login_uses_login_logout_manager_service(ILoginLogoutManager loginLogoutManager,
                                                        ILoginRequest request,
                                                        string username,
                                                        string password)
    {
      // Arrange
      LoginRequestCreator requestCreator = (u, p) => request;
      Mock.Get(loginLogoutManager)
          .Setup(x => x.AttemptLogin(It.IsAny<ILoginRequest>()))
          .Returns(LoginResult.LoginFailed);
      var sut = new LoginController(requestCreator, loginLogoutManager);

      // Act
      sut.Login(username, password);

      // Assert
      Mock.Get(loginLogoutManager).Verify(x => x.AttemptLogin(request), Times.Once());
    }

    [Test, AutoMoqData]
    public void Login_returns_loginresult_from_service(ILoginLogoutManager loginLogoutManager,
                                                       ILoginRequest request,
                                                       string username,
                                                       string password,
                                                       LoginResult loginResult)
    {
      // Arrange
      LoginRequestCreator requestCreator = (u, p) => request;
      Mock.Get(loginLogoutManager)
          .Setup(x => x.AttemptLogin(It.IsAny<ILoginRequest>()))
          .Returns(loginResult);
      var sut = new LoginController(requestCreator, loginLogoutManager);

      // Act
      var result = sut.Login(username, password);

      // Assert
      Assert.AreSame(loginResult, result);
    }

    [Test, AutoMoqData]
    public void Logout_uses_login_logout_manager_service(ILoginLogoutManager loginLogoutManager,
                                                         ILoginRequest request)
    {
      // Arrange
      LoginRequestCreator requestCreator = (u, p) => request;
      Mock.Get(loginLogoutManager)
          .Setup(x => x.AttemptLogout())
          .Returns(LogoutResult.LogoutSuccessful);
      var sut = new LoginController(requestCreator, loginLogoutManager);

      // Act
      sut.Logout();

      // Assert
      Mock.Get(loginLogoutManager).Verify(x => x.AttemptLogout(), Times.Once());
    }

    #endregion
  }
}
