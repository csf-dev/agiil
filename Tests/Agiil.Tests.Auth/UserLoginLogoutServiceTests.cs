using System.Security.Claims;
using Agiil.Auth;
using Agiil.Tests.Attributes;
using CSF.Entities;
using Microsoft.Owin.Security;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Auth
{
  [TestFixture,Parallelizable]
  public class UserLoginLogoutServiceTests
  {
    [Test,AutoMoqData]
    public void LogUserIn_creates_claims_identity_using_factory([Frozen] IClaimsIdentityFactory identityFactory,
                                                                UserLoginLogoutService sut,
                                                                string username,
                                                                IIdentity identity)
    {
      // Act
      sut.LogUserIn(username, identity);

      // Assert
      Mock.Get(identityFactory)
          .Verify(x => x.GetIdentity(username, identity, It.IsAny<string>()), Times.Once());
    }

    [Test,AutoMoqData]
    public void LogUserIn_creates_claims_identity_with_app_cookie_login_type([Frozen] IAuthenticationManager authManager,
                                                                             [Frozen] IClaimsIdentityFactory identityFactory,
                                                                             UserLoginLogoutService sut,
                                                                             string username,
                                                                             IIdentity identity)
    {
      // Act
      sut.LogUserIn(username, identity);

      // Assert
      Mock.Get(identityFactory)
          .Verify(x => x.GetIdentity(It.IsAny<string>(), It.IsAny<IIdentity>(), "ApplicationCookie"), Times.Once());
    }

    [Test,AutoMoqData]
    public void LogUserIn_uses_auth_manager_to_sign_in([Frozen] IAuthenticationManager authManager,
                                                       [Frozen] IClaimsIdentityFactory identityFactory,
                                                       UserLoginLogoutService sut,
                                                       string username,
                                                       IIdentity identity,
                                                       [NoAutoProperties] ClaimsIdentity claimsIdentity)
    {
      // Arrange
      Mock.Get(identityFactory)
          .Setup(x => x.GetIdentity(It.IsAny<string>(), It.IsAny<IIdentity>(), It.IsAny<string>()))
          .Returns(claimsIdentity);

      // Act
      sut.LogUserIn(username, identity);

      // Assert
      Mock.Get(authManager)
          .Verify(x => x.SignIn(It.IsAny<AuthenticationProperties>(), It.IsAny<ClaimsIdentity>()), Times.Once());
    }

    [Test,AutoMoqData]
    public void LogUserIn_passes_claims_identity_to_auth_manager([Frozen] IAuthenticationManager authManager,
                                                                 [Frozen] IClaimsIdentityFactory identityFactory,
                                                                 UserLoginLogoutService sut,
                                                                 string username,
                                                                 IIdentity identity,
                                                                 [NoAutoProperties] ClaimsIdentity claimsIdentity)
    {
      // Arrange
      Mock.Get(identityFactory)
          .Setup(x => x.GetIdentity(It.IsAny<string>(), It.IsAny<IIdentity>(), It.IsAny<string>()))
          .Returns(claimsIdentity);

      // Act
      sut.LogUserIn(username, identity);

      // Assert
      Mock.Get(authManager)
          .Verify(x => x.SignIn(It.IsAny<AuthenticationProperties>(), claimsIdentity), Times.Once());
    }

    [Test,AutoMoqData]
    public void LogUserOut_uses_auth_manager_signout_method([Frozen] IAuthenticationManager authManager,
                                                            UserLoginLogoutService sut)
    {
      // Act
      sut.LogUserOut();

      // Assert
      Mock.Get(authManager).Verify(x => x.SignOut(), Times.Once());
    }
  }
}
