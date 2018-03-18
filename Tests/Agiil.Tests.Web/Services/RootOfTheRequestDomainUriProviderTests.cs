using System;
using Agiil.Web.Services;
using NUnit.Framework;

namespace Agiil.Tests.Web.Services
{
  [TestFixture,Parallelizable]
  public class RootOfTheRequestDomainUriProviderTests
  {
    [Test]
    public void GetBaseUri_returns_root_of_the_domain_when_the_request_has_a_long_path()
    {
      // Arrange
      var requestUri = new Uri("http://example.com/foo/bar/baz");
      var expectedUri = new Uri("http://example.com/");
      var sut = new InjectedUriProvider(requestUri);

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
      var sut = new InjectedUriProvider(requestUri);

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
      var sut = new InjectedUriProvider(requestUri);

      // Act
      var result = sut.GetBaseUri();

      // Assert
      Assert.That(result, Is.EqualTo(expectedUri));
    }

    class InjectedUriProvider : ApplicationRootUriProvider
    {
      readonly Uri injectedRequestUri;

      protected override Uri GetRequestUri()
      {
        return injectedRequestUri ?? base.GetRequestUri();
      }

      public InjectedUriProvider(Uri injectedRequestUri)
      {
        this.injectedRequestUri = injectedRequestUri;
      }
    }
  }
}
