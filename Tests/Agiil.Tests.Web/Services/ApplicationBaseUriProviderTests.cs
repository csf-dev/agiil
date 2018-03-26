using System;
using System.Web.Mvc;
using Agiil.Web.Services;
using Moq;
using NUnit.Framework;

namespace Agiil.Tests.Web.Services
{
  [TestFixture,Parallelizable]
  public class ApplicationBaseUriProviderTests
  {
    [Test]
    public void GetBaseUri_returns_root_of_the_domain_when_the_request_has_a_long_path()
    {
      // Arrange
      var requestUri = new Uri("http://example.com/foo/bar/baz");
      var expectedUri = new Uri("http://example.com/");
      var sut = new ApplicationBaseUriProvider(requestUri, null);

      // Act
      var result = sut.GetBaseUri();

      // Assert
      Assert.That(result, Is.EqualTo(expectedUri));
    }

    [Test]
    public void GetBaseUri_returns_root_of_the_domain_when_the_request_has_a_port()
    {
      // Arrange
      var requestUri = new Uri("http://example.com:8080/foo");
      var expectedUri = new Uri("http://example.com:8080/");
      var sut = new ApplicationBaseUriProvider(requestUri, null);

      // Act
      var result = sut.GetBaseUri();

      // Assert
      Assert.That(result, Is.EqualTo(expectedUri));
    }

    [Test]
    public void GetBaseUri_returns_root_of_the_domain_when_the_request_is_https()
    {
      // Arrange
      var requestUri = new Uri("https://example.com/foo");
      var expectedUri = new Uri("https://example.com/");
      var sut = new ApplicationBaseUriProvider(requestUri, null);

      // Act
      var result = sut.GetBaseUri();

      // Assert
      Assert.That(result, Is.EqualTo(expectedUri));
    }

    [Test]
    public void GetBaseUri_returns_root_of_the_application_when_url_helper_indicates_a_path()
    {
      // Arrange
      var requestUri = new Uri("https://example.com/foo/bar/baz");
      var urlHelper = Mock.Of<UrlHelper>(x => x.Content("~") == "/foo/");
      var expectedUri = new Uri("https://example.com/foo/");
      var sut = new ApplicationBaseUriProvider(requestUri, urlHelper);

      // Act
      var result = sut.GetBaseUri();

      // Assert
      Assert.That(result, Is.EqualTo(expectedUri));
    }
  }
}
