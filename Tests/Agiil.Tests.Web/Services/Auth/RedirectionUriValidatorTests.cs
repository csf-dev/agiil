using System;
using Agiil.Domain;
using Agiil.Tests.Attributes;
using Agiil.Web.Services.Auth;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Web.Services.Auth
{
  [TestFixture,Parallelizable]
  public class RedirectionUriValidatorTests
  {
    [Test,AutoMoqData]
    public void IsValid_returns_false_if_uri_string_is_null(RedirectionUriValidator sut)
    {
      // Act
      var result = sut.IsValid((string) null);

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void IsValid_returns_false_if_uri_string_is_empty(RedirectionUriValidator sut)
    {
      // Act
      var result = sut.IsValid(String.Empty);

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void IsValid_returns_false_if_uri_string_is_not_relative_to_base([Frozen] IProvidesApplicationBaseUri baseUriProvider,
                                                                            RedirectionUriValidator sut)
    {
      // Arrange
      Mock.Get(baseUriProvider)
          .Setup(x => x.GetBaseUri())
          .Returns(new Uri("http://example.com/"));
      
      // Act
      var result = sut.IsValid("http://badwebsite.com/attack_page");

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void IsValid_returns_true_if_uri_string_is_relative_to_base([Frozen] IProvidesApplicationBaseUri baseUriProvider,
                                                                       RedirectionUriValidator sut)
    {
      // Arrange
      Mock.Get(baseUriProvider)
          .Setup(x => x.GetBaseUri())
          .Returns(new Uri("http://example.com/"));

      // Act
      var result = sut.IsValid("http://example.com/different/page");

      // Assert
      Assert.That(result, Is.True);
    }

    [Test,AutoMoqData]
    public void IsValid_returns_true_if_uri_string_is_a_relative_uri([Frozen] IProvidesApplicationBaseUri baseUriProvider,
                                                                     RedirectionUriValidator sut)
    {
      // Arrange
      Mock.Get(baseUriProvider)
          .Setup(x => x.GetBaseUri())
          .Returns(new Uri("http://example.com/"));

      // Act
      var result = sut.IsValid(new Uri("nice/uri", UriKind.Relative));

      // Assert
      Assert.That(result, Is.True);
    }

    [Test,AutoMoqData]
    public void IsValid_returns_true_if_uri_string_is_a_domain_relative_uri([Frozen] IProvidesApplicationBaseUri baseUriProvider,
                                                                            RedirectionUriValidator sut)
    {
      // Arrange
      Mock.Get(baseUriProvider)
          .Setup(x => x.GetBaseUri())
          .Returns(new Uri("http://example.com/"));

      // Act
      var result = sut.IsValid("/nice/uri");

      // Assert
      Assert.That(result, Is.True);
    }

    [Test,AutoMoqData]
    public void IsValid_returns_false_if_uri_string_is_outside_base_url_path([Frozen] IProvidesApplicationBaseUri baseUriProvider,
                                                                             RedirectionUriValidator sut)
    {
      // Arrange
      Mock.Get(baseUriProvider)
          .Setup(x => x.GetBaseUri())
          .Returns(new Uri("http://example.com/site_root/"));

      // Act
      var result = sut.IsValid("/bad/path");

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void IsValid_returns_true_if_uri_string_is_inside_base_url_path([Frozen] IProvidesApplicationBaseUri baseUriProvider,
                                                                           RedirectionUriValidator sut)
    {
      // Arrange
      Mock.Get(baseUriProvider)
          .Setup(x => x.GetBaseUri())
          .Returns(new Uri("http://example.com/site_root/"));

      // Act
      var result = sut.IsValid("/site_root/path/good_page");

      // Assert
      Assert.That(result, Is.True);
    }
  }
}
