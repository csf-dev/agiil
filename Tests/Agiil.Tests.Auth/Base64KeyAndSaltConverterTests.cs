using NUnit.Framework;
using System;
using Moq;
using Agiil.Auth;

namespace Agiil.Tests.Auth
{
  [TestFixture ()]
  public class Base64KeyAndSaltConverterTests
  {
    #region fields

    IKeyAndSaltConverter sut;
    string sampleAuthenticationInfo = "aGVyZSwgd2UgaGF2ZSBhIHRlc3Qgc2FsdAo=:dGhpcyBpcyBhIHRlc3Qga2V5Cg==";
    IAuthenticationInfoProvider provider;
    byte[]
      sampleSaltBytes = { 104, 101, 114, 101, 44, 32, 119, 101, 32, 104, 97, 118, 101, 32, 97, 32, 116, 101, 115, 116, 32, 115, 97, 108, 116, 10 },
      sampleKeyBytes = { 116, 104, 105, 115, 32, 105, 115, 32, 97, 32, 116, 101, 115, 116, 32, 107, 101, 121, 10 };

    #endregion

    #region setup

    [SetUp]
    public void Setup ()
    {
      sut = new Base64KeyAndSaltConverter ();
      provider = Mock.Of<IAuthenticationInfoProvider>(x => x.GetAuthenticationInfo() == sampleAuthenticationInfo);
    }

    #endregion

    #region tests

    [Test]
    public void GetKeyAndSalt_gets_expected_key ()
    {
      // Act
      var result = sut.GetKeyAndSalt(sampleAuthenticationInfo);

      // Assert
      CollectionAssert.AreEqual(sampleKeyBytes, result.GetKeyAsByteArray());
    }

    [Test]
    public void GetKeyAndSalt_gets_expected_salt ()
    {
      // Act
      var result = sut.GetKeyAndSalt(sampleAuthenticationInfo);

      // Assert
      CollectionAssert.AreEqual(sampleSaltBytes, result.GetSaltAsByteArray());
    }

    [Test]
    public void GetKeyAndSalt_gets_expected_key_from_IAuthenticationInfoProvider ()
    {
      // Act
      var result = sut.GetKeyAndSalt(provider);

      // Assert
      CollectionAssert.AreEqual(sampleKeyBytes, result.GetKeyAsByteArray());
    }

    [Test]
    public void GetKeyAndSalt_gets_expected_salt_from_IAuthenticationInfoProvider ()
    {
      // Act
      var result = sut.GetKeyAndSalt(provider);

      // Assert
      CollectionAssert.AreEqual(sampleSaltBytes, result.GetSaltAsByteArray());
    }

    [Test]
    public void GetKeyAndSalt_throws_exception_for_improperly_formatted_input ()
    {
      // Act & Assert
      Assert.Throws<FormatException>(() => sut.GetKeyAndSalt("Invalid input"));
    }

    [Test]
    public void GetKeyAndSalt_throws_exception_for_null_input_string ()
    {
      // Act & Assert
      Assert.Throws<ArgumentNullException>(() => sut.GetKeyAndSalt((string) null));
    }

    [Test]
    public void GetKeyAndSalt_throws_exception_for_null_IAuthenticationInfoProvider ()
    {
      // Act & Assert
      Assert.Throws<ArgumentNullException>(() => sut.GetKeyAndSalt((IAuthenticationInfoProvider) null));
    }

    #endregion
  }
}
