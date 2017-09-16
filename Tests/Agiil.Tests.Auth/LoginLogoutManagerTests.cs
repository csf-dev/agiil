using System;
using System.Security.Claims;
using Agiil.Auth;
using Agiil.Domain.Auth;
using CSF.Entities;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Auth
{
  [TestFixture]
  public class LoginLogoutManagerTests
  {
    #region tests

    [Test, AutoMoqData]
    public void AttemptLogin_returns_failure_result_when_authentication_fails([Frozen] CSF.Security.Authentication.IPasswordAuthenticationService authService,
                                                                              LoginLogoutManager sut,
                                                                              ILoginRequest request,
                                                                              LoginCredentials credentials,
                                                                              [HasIdentity] User user)
    {
      // Arrange
      Mock.Get(request)
          .Setup(x => x.GetCredentials())
          .Returns(credentials);
      Mock.Get(authService)
          .Setup(x => x.Authenticate(credentials))
          .Returns(new AuthenticationResult(user.GetIdentity(), user.Username, false));

      // Act
      var result = sut.AttemptLogin(request);

      // Assert
      Assert.IsFalse(result.Success);
    }

    [Test, AutoMoqData]
    public void AttemptLogin_returns_failure_result_when_user_is_not_found([Frozen] CSF.Security.Authentication.IPasswordAuthenticationService authService,
                                                                           LoginLogoutManager sut,
                                                                           ILoginRequest request,
                                                                           LoginCredentials credentials)
    {
      // Arrange
      Mock.Get(request)
          .Setup(x => x.GetCredentials())
          .Returns(credentials);
      Mock.Get(authService)
          .Setup(x => x.Authenticate(credentials))
          .Returns(AuthenticationResult.UserNotFound);

      // Act
      var result = sut.AttemptLogin(request);

      // Assert
      Assert.IsFalse(result.Success);
    }

    [Test, AutoMoqData]
    public void AttemptLogin_does_not_log_user_in_when_authentication_fails([Frozen] CSF.Security.Authentication.IPasswordAuthenticationService authService,
                                                                            [Frozen] IAuthenticationManager authManager,
                                                                            LoginLogoutManager sut,
                                                                            ILoginRequest request,
                                                                            LoginCredentials credentials,
                                                                            [HasIdentity] User user)
    {
      // Arrange
      Mock.Get(request)
          .Setup(x => x.GetCredentials())
          .Returns(credentials);
      Mock.Get(authService)
          .Setup(x => x.Authenticate(credentials))
          .Returns(new AuthenticationResult(user.GetIdentity(), user.Username, false));

      // Act
      sut.AttemptLogin(request);

      // Assert
      Mock.Get(authManager)
          .Verify(x => x.SignIn(It.IsAny<AuthenticationProperties>(), It.IsAny<ClaimsIdentity[]>()), Times.Never());
    }

    [Test, AutoMoqData]
    public void AttemptLogin_does_not_log_user_in_when_user_is_not_found([Frozen] CSF.Security.Authentication.IPasswordAuthenticationService authService,
                                                                         [Frozen] IAuthenticationManager authManager,
                                                                         LoginLogoutManager sut,
                                                                         ILoginRequest request,
                                                                         LoginCredentials credentials)
    {
      // Arrange
      Mock.Get(request)
          .Setup(x => x.GetCredentials())
          .Returns(credentials);
      Mock.Get(authService)
          .Setup(x => x.Authenticate(credentials))
          .Returns(AuthenticationResult.UserNotFound);

      // Act
      sut.AttemptLogin(request);

      // Assert
      Mock.Get(authManager)
          .Verify(x => x.SignIn(It.IsAny<AuthenticationProperties>(), It.IsAny<ClaimsIdentity[]>()), Times.Never());
    }

    [Test, AutoMoqData]
    public void AttemptLogin_signs_user_in_when_authentication_succeeds([Frozen] CSF.Security.Authentication.IPasswordAuthenticationService authService,
                                                                        [Frozen] IAuthenticationManager authManager,
                                                                        [Frozen] IClaimsIdentityFactory identityFactory,
                                                                        LoginLogoutManager sut,
                                                                        ILoginRequest request,
                                                                        LoginCredentials credentials,
                                                                        [HasIdentity] User user)
    {
      // Arrange
      user.Username = credentials.Username;
      Mock.Get(request)
          .Setup(x => x.GetCredentials())
          .Returns(credentials);
      Mock.Get(authService)
          .Setup(x => x.Authenticate(credentials))
          .Returns(new AuthenticationResult(user.GetIdentity(), user.Username, true));

      var identity = new ClaimsIdentity();
      Mock.Get(identityFactory)
          .Setup(x => x.GetIdentity(It.IsAny<IAuthenticationResult>(), It.IsAny<string>()))
          .Returns(identity);

      Mock.Get(authManager)
          .Setup(x => x.SignIn(It.IsAny<AuthenticationProperties>(), identity));

      // Act
      sut.AttemptLogin(request);

      // Assert
      Mock.Get(authManager)
          .Verify(x => x.SignIn(It.IsAny<AuthenticationProperties>(), identity), Times.Once());
    }

    [Test, AutoMoqData]
    public void AttemptLogin_returns_success_result_when_authentication_succeeds([Frozen] CSF.Security.Authentication.IPasswordAuthenticationService authService,
                                                                                 [Frozen] IAuthenticationManager authManager,
                                                                                 [Frozen] IClaimsIdentityFactory identityFactory,
                                                                                 LoginLogoutManager sut,
                                                                                 ILoginRequest request,
                                                                                 LoginCredentials credentials,
                                                                                 [HasIdentity] User user)
    {
      // Arrange
      Mock.Get(request)
          .Setup(x => x.GetCredentials())
          .Returns(credentials);
      Mock.Get(authService)
          .Setup(x => x.Authenticate(credentials))
          .Returns(new AuthenticationResult(user.GetIdentity(), user.Username, true));

      var identity = new ClaimsIdentity();
      Mock.Get(identityFactory)
          .Setup(x => x.GetIdentity(It.IsAny<IAuthenticationResult>(), It.IsAny<string>()))
          .Returns(identity);

      user.Username = credentials.Username;
      user.GenerateIdentity();

      // Act
      var result = sut.AttemptLogin(request);

      // Assert
      Assert.IsTrue(result.Success);
    }

    #endregion
  }
}
