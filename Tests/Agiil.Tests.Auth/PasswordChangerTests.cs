using System;
using Agiil.Auth;
using Agiil.Domain.Auth;
using Agiil.Tests.Attributes;
using CSF.Entities;
using CSF.Security.Authentication;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Auth
{
  [TestFixture]
  public class PasswordChangerTests
  {
    [Test,AutoMoqData]
    public void ChangeOwnPassword_returns_success_response_when_request_is_valid([Frozen] IPasswordPolicy policy,
                                                                                 [Frozen] IPasswordAuthenticationService authService,
                                                                                 [LoggedIn] User currentUser,
                                                                                 PasswordChanger sut,
                                                                                 PasswordChangeRequest request)
    {
      // Arrange
      Mock.Get(authService)
          .Setup(x => x.Authenticate(It.IsAny<IPassword>()))
          .Returns(Mock.Of<CSF.Security.Authentication.IAuthenticationResult>(x => x.Success == true));
      Mock.Get(policy)
          .Setup(x => x.IsPasswordOk(request.NewPassword, currentUser))
          .Returns(true);
      request.ConfirmNewPassword = request.NewPassword;

      // Act
      var result = sut.ChangeOwnPassword(request);

      // Assert
      Assert.IsTrue(result.Success);
    }

    [Test,AutoMoqData]
    public void ChangeOwnPassword_stores_updated_password_when_when_request_is_valid([Frozen] IPasswordPolicy policy,
                                                                                     [Frozen] IPasswordAuthenticationService authService,
                                                                                     [LoggedIn] User currentUser,
                                                                                     [Frozen] IUserPasswordUpdater updater,
                                                                                     PasswordChanger sut,
                                                                                     PasswordChangeRequest request)
    {
      // Arrange
      Mock.Get(authService)
          .Setup(x => x.Authenticate(It.IsAny<IPassword>()))
          .Returns(Mock.Of<CSF.Security.Authentication.IAuthenticationResult>(x => x.Success == true));
      Mock.Get(policy)
          .Setup(x => x.IsPasswordOk(request.NewPassword, currentUser))
          .Returns(true);
      request.ConfirmNewPassword = request.NewPassword;

      // Act
      sut.ChangeOwnPassword(request);

      // Assert
      Mock.Get(updater)
          .Verify(x => x.ChangePassword(currentUser, request.NewPassword), Times.Once());
    }

    [Test,AutoMoqData]
    public void ChangeOwnPassword_returns_failure_result_if_new_passwords_do_not_match([Frozen] IPasswordPolicy policy,
                                                                                       [Frozen] IPasswordAuthenticationService authService,
                                                                                       [LoggedIn] User currentUser,
                                                                                       PasswordChanger sut,
                                                                                       PasswordChangeRequest request)
    {
      // Arrange
      Mock.Get(authService)
          .Setup(x => x.Authenticate(It.IsAny<IPassword>()))
          .Returns(Mock.Of<CSF.Security.Authentication.IAuthenticationResult>(x => x.Success == true));
      Mock.Get(policy)
          .Setup(x => x.IsPasswordOk(request.NewPassword, currentUser))
          .Returns(true);
      request.NewPassword = "One password";
      request.NewPassword = "A different password";

      // Act
      var result = sut.ChangeOwnPassword(request);

      // Assert
      Assert.IsFalse(result.Success);
    }

    [Test,AutoMoqData]
    public void ChangeOwnPassword_returns_failure_result_if_new_passwords_do_not_meet_policy([Frozen] IPasswordPolicy policy,
                                                                                             [Frozen] IPasswordAuthenticationService authService,
                                                                                             [LoggedIn] User currentUser,
                                                                                             PasswordChanger sut,
                                                                                             PasswordChangeRequest request)
    {
      // Arrange
      Mock.Get(authService)
          .Setup(x => x.Authenticate(It.IsAny<IPassword>()))
          .Returns(Mock.Of<CSF.Security.Authentication.IAuthenticationResult>(x => x.Success == true));
      Mock.Get(policy)
          .Setup(x => x.IsPasswordOk(request.NewPassword, currentUser))
          .Returns(false);
      request.ConfirmNewPassword = request.NewPassword;

      // Act
      var result = sut.ChangeOwnPassword(request);

      // Assert
      Assert.IsFalse(result.Success);
    }

    [Test,AutoMoqData]
    public void ChangeOwnPassword_returns_failure_result_if_existing_password_is_incorrect([Frozen] IPasswordPolicy policy,
                                                                                           [Frozen] IPasswordAuthenticationService authService,
                                                                                           [LoggedIn] User currentUser,
                                                                                           PasswordChanger sut,
                                                                                           PasswordChangeRequest request)
    {
      // Arrange
      Mock.Get(authService)
          .Setup(x => x.Authenticate(It.IsAny<IPassword>()))
          .Returns(Mock.Of<CSF.Security.Authentication.IAuthenticationResult>(x => x.Success == false));
      Mock.Get(policy)
          .Setup(x => x.IsPasswordOk(request.NewPassword, currentUser))
          .Returns(true);
      request.ConfirmNewPassword = request.NewPassword;

      // Act
      var result = sut.ChangeOwnPassword(request);

      // Assert
      Assert.IsFalse(result.Success);
    }
  }
}
