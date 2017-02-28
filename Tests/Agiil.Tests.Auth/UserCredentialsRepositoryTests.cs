using System;
using CSF.Data;
using CSF.Data.Entities;
using Agiil.Domain.Auth;
using Agiil.Tests.Common;
using CSF.Security;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;
using Agiil.Auth;

namespace Agiil.Tests.Auth
{
  [TestFixture]
  public class UserCredentialsRepositoryTests
  {
    #region fields

    InMemoryQuery query;
    Mock<IKeyAndSaltConverter> converter;
    Agiil.Auth.ICredentialsRepository sut;
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
      user.GenerateIdentity();
      user.Username = credentials.Username;
      query.Add(user);

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
      user.GenerateIdentity();
      user.Username = credentials.Username;
      query.Add(user);

      // Act
      sut.GetStoredCredentials(credentials);

      // Assert
      converter.Verify(x => x.GetKeyAndSalt(user), Times.Once());
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
