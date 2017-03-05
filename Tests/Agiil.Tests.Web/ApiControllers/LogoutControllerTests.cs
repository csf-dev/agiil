using System;
using Agiil.Auth;
using Agiil.Tests.Common;
using Agiil.Web.ApiControllers;
using Moq;
using NUnit.Framework;

namespace Agiil.Tests.Web.ApiControllers
{
  public class LogoutControllerTests
  {
    #region tests

    [Test, AutoMoqData]
    public void Logout_uses_login_logout_manager_service(ILoginLogoutManager loginLogoutManager)
    {
      // Arrange
      Mock.Get(loginLogoutManager)
          .Setup(x => x.AttemptLogout())
          .Returns(LogoutResult.LogoutSuccessful);
      var sut = new LogoutController(loginLogoutManager);

      // Act
      sut.Logout();

      // Assert
      Mock.Get(loginLogoutManager).Verify(x => x.AttemptLogout(), Times.Once());
    }

    #endregion
  }
}
