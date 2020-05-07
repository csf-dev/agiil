using System;
using CSF.ORM;
using Agiil.Domain.Auth;
using CSF.Security;
using Moq;
using NUnit.Framework;
using AutoFixture.NUnit3;
using Agiil.Auth;
using CSF.Entities;
using Agiil.Tests.Attributes;
using CSF.ORM.InMemory;

namespace Agiil.Tests.Auth
{
  [TestFixture,Parallelizable]
  public class UserCredentialsRepositoryTests
  {
    #region tests

    [Test,AutoMoqData]
    public void GetStoredCredentials_returns_null_when_no_user_found (LoginCredentials credentials,
                                                                      UserCredentialsRepository sut)
    {
      // Act
      var result = sut.GetStoredCredentials(credentials);

      // Assert
      Assert.IsNull(result);
    }

    [Test, AutoMoqData]
    public void GetStoredCredentials_returns_credentials_when_user_is_found (LoginCredentials credentials,
                                                                             User user,
                                                                             [Frozen,InMemory] IEntityData data,
                                                                             UserCredentialsRepository sut)
    {
      // Arrange
      user.GenerateIdentity();
      user.Username = credentials.Username;
            data.Add(user);

      // Act
      var result = sut.GetStoredCredentials(credentials);

      // Assert
      Assert.NotNull(result);
    }

    [Test, AutoMoqData]
    public void GetStoredCredentials_returns_matching_serialized_credentials_when_user_found (LoginCredentials credentials,
                                                                                              User user,
                                                                             [Frozen, InMemory] IEntityData data,
                                                                                              UserCredentialsRepository sut)
    {
      // Arrange
      user.GenerateIdentity();
      user.Username = credentials.Username;
            data.Add(user);

            // Act
            var result = sut.GetStoredCredentials(credentials);

      // Assert
      Assert.AreEqual(user.SerializedCredentials, result.SerializedCredentials);
    }

    [Test, AutoMoqData]
    public void GetStoredCredentials_returns_correct_username_when_user_found (LoginCredentials credentials,
                                                                               User user,
                                                                             [Frozen, InMemory] IEntityData data,
                                                                               UserCredentialsRepository sut)
    {
      // Arrange
      user.GenerateIdentity();
      user.Username = credentials.Username;
            data.Add(user);

            // Act
            var result = sut.GetStoredCredentials(credentials);

      // Assert
      Assert.AreEqual(user.Username, result.UserInformation.Username);
    }

    [Test, AutoMoqData]
    public void GetStoredCredentials_returns_correct_identity_when_user_found (LoginCredentials credentials,
                                                                               User user,
                                                                             [Frozen,InMemory] IEntityData data,
                                                                               UserCredentialsRepository sut)
    {
      // Arrange
      user.GenerateIdentity();
      user.Username = credentials.Username;
            data.Add(user);

            // Act
            var result = sut.GetStoredCredentials(credentials);

      // Assert
      Assert.AreEqual(user.GetIdentity(), result.UserInformation.Identity);
    }

    [Test, AutoMoqData]
    public void GetStoredCredentials_throws_exception_when_credentials_are_null (UserCredentialsRepository sut)
    {
      // Act & Assert
      Assert.Throws<ArgumentNullException>(() => sut.GetStoredCredentials(null));
    }

    #endregion
  }
}
