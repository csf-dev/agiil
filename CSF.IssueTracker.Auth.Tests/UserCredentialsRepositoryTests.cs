﻿using System;
using CSF.Data;
using CSF.Entities;
using CSF.IssueTracker.Domain.Auth;
using CSF.IssueTracker.Tests.Common;
using CSF.Security;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace CSF.IssueTracker.Auth.Tests
{
  [TestFixture]
  public class UserCredentialsRepositoryTests
  {
    #region fields

    InMemoryQuery query;
    Mock<IKeyAndSaltConverter> converter;
    ICredentialsRepository sut;
    IStoredCredentialsWithKeyAndSalt storedCredentials;

    #endregion

    #region setup

    [SetUp]
    public void Setup ()
    {
      query = new InMemoryQuery();
      converter = new Mock<IKeyAndSaltConverter>();
      sut = new UserCredentialsRepository(query, converter.Object);

      storedCredentials = Mock.Of<IStoredCredentialsWithKeyAndSalt>();

      converter
        .Setup(x => x.GetKeyAndSalt(It.IsAny<IAuthenticationInfoProvider>()))
        .Returns(storedCredentials);
    }

    #endregion

    #region tests

    [Test,AutoData]
    public void GetStoredCredentials_returns_null_when_no_user_found (LoginCredentials credentials)
    {
      // Act
      var result = sut.GetStoredCredentials(credentials);

      // Assert
      Assert.IsNull(result);
    }

    [Test,AutoData]
    public void GetStoredCredentials_returns_credentials_when_user_is_found (LoginCredentials credentials,
                                                                             User user)
    {
      // Arrange
      user.SetIdentity();
      user.Username = credentials.Username;
      query.Add(user, user.GetIdentity());

      // Act
      var result = sut.GetStoredCredentials(credentials);

      // Assert
      Assert.AreSame(storedCredentials, result);
    }

    [Test,AutoData]
    public void GetStoredCredentials_uses_key_and_salt_converter (LoginCredentials credentials,
                                                                  User user)
    {
      // Arrange
      user.SetIdentity();
      user.Username = credentials.Username;
      query.Add(user, user.GetIdentity());

      // Act
      sut.GetStoredCredentials(credentials);

      // Assert
      converter.Verify(x => x.GetKeyAndSalt(user), Times.Once());
    }

    [Test]
    public void GetStoredCredentials_throws_exception_when_credentials_are_null ()
    {
      // Act & Assert
      Assert.Throws<ArgumentNullException>(() => sut.GetStoredCredentials((LoginCredentials) null));

      // Assert
    }

    #endregion
  }
}
