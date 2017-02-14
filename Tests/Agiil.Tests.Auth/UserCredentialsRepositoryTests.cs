﻿using System;
using CSF.Data;
using CSF.Data.Entities;
using Agiil.Domain.Auth;
using Agiil.Tests.Common;
using CSF.Security;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;
using Agiil.Auth;
using CSF.Entities;

namespace Agiil.Tests.Auth
{
  [TestFixture]
  public class UserCredentialsRepositoryTests
  {
    #region fields

    InMemoryQuery query;
    UserCredentialsRepository sut;

    #endregion

    #region setup

    [SetUp]
    public void Setup ()
    {
      query = new InMemoryQuery();
      sut = new UserCredentialsRepository(query);
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
      user.GenerateIdentity();
      user.Username = credentials.Username;
      query.Add(user);

      // Act
      var result = sut.GetStoredCredentials(credentials);

      // Assert
      Assert.NotNull(result);
    }

    [Test,AutoData]
    public void GetStoredCredentials_returns_matching_serialized_credentials_when_user_found (LoginCredentials credentials,
                                                                                              User user)
    {
      // Arrange
      user.GenerateIdentity();
      user.Username = credentials.Username;
      query.Add(user);

      // Act
      var result = sut.GetStoredCredentials(credentials);

      // Assert
      Assert.AreEqual(user.SerializedCredentials, result.SerializedCredentials);
    }

    [Test,AutoData]
    public void GetStoredCredentials_returns_correct_username_when_user_found (LoginCredentials credentials,
                                                                               User user)
    {
      // Arrange
      user.GenerateIdentity();
      user.Username = credentials.Username;
      query.Add(user);

      // Act
      var result = sut.GetStoredCredentials(credentials);

      // Assert
      Assert.AreEqual(user.Username, result.UserInformation.Username);
    }

    [Test,AutoData]
    public void GetStoredCredentials_returns_correct_identity_when_user_found (LoginCredentials credentials,
                                                                               User user)
    {
      // Arrange
      user.GenerateIdentity();
      user.Username = credentials.Username;
      query.Add(user);

      // Act
      var result = sut.GetStoredCredentials(credentials);

      // Assert
      Assert.AreEqual(user.GetIdentity(), result.UserInformation.Identity);
    }

    [Test]
    public void GetStoredCredentials_throws_exception_when_credentials_are_null ()
    {
      // Act & Assert
      Assert.Throws<ArgumentNullException>(() => sut.GetStoredCredentials(null));
    }

    #endregion
  }
}
