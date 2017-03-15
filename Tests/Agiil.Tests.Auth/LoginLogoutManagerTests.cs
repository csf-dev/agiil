using System;
using System.Linq;
using System.Security.Claims;
using CSF.Data;
using CSF.Entities;
using Agiil.Domain.Auth;
using Agiil.Tests.Common;
using CSF.Security.Authentication;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;
using Agiil.Auth;

namespace Agiil.Tests.Auth
{
  [TestFixture]
  public class LoginLogoutManagerTests
  {
    #region tests

    [Test, AutoMoqData]
    public void AttemptLogin_returns_failure_result_when_authentication_fails([Frozen] IPasswordAuthenticationService authService,
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
          .Returns(new AuthenticationResult(true, false));

      // Act
      var result = sut.AttemptLogin(request);

      // Assert
      Assert.IsFalse(result.Success);
    }

    [Test, AutoMoqData]
    public void AttemptLogin_returns_failure_result_when_user_is_not_found([Frozen] IPasswordAuthenticationService authService,
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
          .Returns(new AuthenticationResult(false, false));

      // Act
      var result = sut.AttemptLogin(request);

      // Assert
      Assert.IsFalse(result.Success);
    }

    [Test, AutoMoqData]
    public void AttemptLogin_does_not_log_user_in_when_authentication_fails([Frozen] IPasswordAuthenticationService authService,
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
          .Returns(new AuthenticationResult(true, false));

      // Act
      sut.AttemptLogin(request);

      // Assert
      Mock.Get(authManager)
          .Verify(x => x.SignIn(It.IsAny<AuthenticationProperties>(), It.IsAny<ClaimsIdentity[]>()), Times.Never());
    }

    [Test, AutoMoqData]
    public void AttemptLogin_does_not_log_user_in_when_user_is_not_found([Frozen] IPasswordAuthenticationService authService,
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
          .Returns(new AuthenticationResult(false, false));

      // Act
      sut.AttemptLogin(request);

      // Assert
      Mock.Get(authManager)
          .Verify(x => x.SignIn(It.IsAny<AuthenticationProperties>(), It.IsAny<ClaimsIdentity[]>()), Times.Never());
    }

    [Test, AutoMoqData]
    public void AttemptLogin_signs_user_in_when_authentication_succeeds([Frozen] IPasswordAuthenticationService authService,
                                                                        [Frozen] IAuthenticationManager authManager,
                                                                        [Frozen] InMemoryQuery query,
                                                                        ILoginRequest request,
                                                                        LoginCredentials credentials,
                                                                        User user)
    {
      // Arrange
      Mock.Get(request)
          .Setup(x => x.GetCredentials())
          .Returns(credentials);
      Mock.Get(authService)
          .Setup(x => x.Authenticate(credentials))
          .Returns(new AuthenticationResult(true, true));
      
      user.Username = credentials.Username;
      user.GenerateIdentity();
      query.Add(user, user.GetIdentity().Value);

      ClaimsIdentity identity = null;
      Mock.Get(authManager)
          .Setup(x => x.SignIn(It.IsAny<AuthenticationProperties>(), It.IsAny<ClaimsIdentity[]>()))
          .Callback((AuthenticationProperties props, ClaimsIdentity[] ident) => identity = ident.Single());

      var sut = new LoginLogoutManager(authService, query, authManager);

      // Act
      sut.AttemptLogin(request);

      // Assert
      Mock.Get(authManager)
          .Verify(x => x.SignIn(It.IsAny<AuthenticationProperties>(), It.IsAny<ClaimsIdentity[]>()),
                  Times.Once(),
                  "Authentication manager must be invoked");

      var expectedClaims = new [] {
        new { type = ClaimTypes.NameIdentifier, value = user.Username },
        new { type = CustomClaimTypes.UserNumericId, value = user.GetIdentity().Value.ToString() },
      };
      var actualClaims = identity.Claims.Select(x => new { type = x.Type, value = x.Value }).ToArray();
      CollectionAssert.AreEquivalent(expectedClaims, actualClaims, "Expected claims must be set");
    }

    [Test, AutoMoqData]
    public void AttemptLogin_returns_success_result_when_authentication_succeeds([Frozen] IPasswordAuthenticationService authService,
                                                                                 [Frozen] IAuthenticationManager authManager,
                                                                                 [Frozen] InMemoryQuery query,
                                                                                 ILoginRequest request,
                                                                                 LoginCredentials credentials,
                                                                                 User user)
    {
      // Arrange
      Mock.Get(request)
          .Setup(x => x.GetCredentials())
          .Returns(credentials);
      Mock.Get(authService)
          .Setup(x => x.Authenticate(credentials))
          .Returns(new AuthenticationResult(true, true));

      user.Username = credentials.Username;
      user.GenerateIdentity();
      query.Add(user, user.GetIdentity().Value);

      var sut = new LoginLogoutManager(authService, query, authManager);

      // Act
      var result = sut.AttemptLogin(request);

      // Assert
      Assert.IsTrue(result.Success);
    }

    #endregion
  }
}
