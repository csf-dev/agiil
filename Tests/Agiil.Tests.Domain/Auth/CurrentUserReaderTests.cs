using NUnit.Framework;
using System;
using Agiil.Tests.Common;
using Ploeh.AutoFixture.NUnit3;
using CSF.Data;
using Agiil.Domain.Auth;
using Moq;
using CSF.Entities;

namespace Agiil.Tests.Services.Auth
{
  [TestFixture]
  public class CurrentUserReaderTests
  {
    [Test, AutoMoqData]
    public void RequireCurrentUser_returns_user_when_they_are_logged_in([Frozen] IIdentityReader identityReader,
                                                                        [Frozen,ProvidesService(typeof(IQuery))] InMemoryQuery query,
                                                                        CurrentUserReader sut,
                                                                        ICurrentUserInfo userInfo,
                                                                        [HasIdentity] User user)
    {
      // Arrange
      FullySetupLoggedInUser(user, userInfo, query, identityReader);

      // Act
      var result = sut.RequireCurrentUser();

      // Assert
      Assert.AreSame(user, result);
    }

    [Test, AutoMoqData]
    public void RequireCurrentUser_raises_exception_when_they_are_not_logged_in([Frozen] IIdentityReader identityReader,
                                                                                [Frozen,ProvidesService(typeof(IQuery))] InMemoryQuery query,
                                                                                CurrentUserReader sut)
    {
      // Arrange
      Mock.Get(identityReader)
          .Setup(x => x.GetCurrentUserInfo())
          .Returns((ICurrentUserInfo) null);

      // Act & assert
      Assert.Throws<CurrentUserNotIdentifiedException>(() => sut.RequireCurrentUser());
    }

    [Test, AutoMoqData]
    public void RequireCurrentUser_raises_exception_when_they_are_not_found([Frozen] IIdentityReader identityReader,
                                                                            [Frozen,ProvidesService(typeof(IQuery))] InMemoryQuery query,
                                                                            CurrentUserReader sut,
                                                                            ICurrentUserInfo userInfo,
                                                                            [HasIdentity] User user)
    {
      // Arrange
      SetupCurrentUserIdentity(user, userInfo, identityReader);

      // Act & assert
      Assert.Throws<CurrentUserNotIdentifiedException>(() => sut.RequireCurrentUser());
    }

    [Test, AutoMoqData]
    public void GetCurrentUser_returns_user_when_they_are_logged_in([Frozen] IIdentityReader identityReader,
                                                                    [Frozen,ProvidesService(typeof(IQuery))] InMemoryQuery query,
                                                                    CurrentUserReader sut,
                                                                    ICurrentUserInfo userInfo,
                                                                    [HasIdentity] User user)
    {
      // Arrange
      FullySetupLoggedInUser(user, userInfo, query, identityReader);

      // Act
      var result = sut.GetCurrentUser();

      // Assert
      Assert.AreSame(user, result);
    }

    [Test, AutoMoqData]
    public void GetCurrentUser_returns_null_when_they_are_not_logged_in([Frozen] IIdentityReader identityReader,
                                                                        [Frozen,ProvidesService(typeof(IQuery))] InMemoryQuery query,
                                                                        CurrentUserReader sut)
    {
      // Arrange
      Mock.Get(identityReader)
          .Setup(x => x.GetCurrentUserInfo())
          .Returns((ICurrentUserInfo) null);

      // Act
      var result = sut.GetCurrentUser();

      // Assert
      Assert.IsNull(result);
    }

    [Test, AutoMoqData]
    public void GetCurrentUser_returns_null_when_they_are_not_found([Frozen] IIdentityReader identityReader,
                                                                    [Frozen,ProvidesService(typeof(IQuery))] InMemoryQuery query,
                                                                    CurrentUserReader sut,
                                                                    ICurrentUserInfo userInfo,
                                                                    [HasIdentity] User user)
    {
      // Arrange
      SetupCurrentUserIdentity(user, userInfo, identityReader);

      // Act
      var result = sut.GetCurrentUser();

      // Assert
      Assert.IsNull(result);
    }

    private void FullySetupLoggedInUser(User user,
                                        ICurrentUserInfo userInfo,
                                        InMemoryQuery query,
                                        IIdentityReader identityReader)
    {
      SetupCurrentUserIdentity(user, userInfo, identityReader);
      query.Add(new [] { user }, x => x.GetIdentity().Value);
    }

    private void SetupCurrentUserIdentity(User user,
                                          ICurrentUserInfo userInfo,
                                          IIdentityReader identityReader)
    {
      Mock.Get(userInfo)
          .SetupGet(x => x.Identity)
          .Returns(user.GetIdentity());
      Mock.Get(identityReader)
          .Setup (x => x.GetCurrentUserInfo())
          .Returns(userInfo);
    }
  }
}
