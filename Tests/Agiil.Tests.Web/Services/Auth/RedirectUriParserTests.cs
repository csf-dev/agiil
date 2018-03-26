using System;
using Agiil.Web.Services.Auth;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Web.Services.Auth
{
  [TestFixture,Parallelizable]
  public class RedirectUriParserTests
  {
    [Test,AutoData]
    public void Parse_can_return_absolute_uri(RedirectUriParser sut)
    {
      // Act
      var result = sut.Parse("http://example.com/path/file");

      // Assert
      Assert.That(result, Is.EqualTo(new Uri("http://example.com/path/file")));
      Assert.That(result.IsAbsoluteUri, Is.True);
    }

    [Test,AutoData]
    public void Parse_can_return_relative_uri(RedirectUriParser sut)
    {
      // Act
      var result = sut.Parse("path/file");

      // Assert
      Assert.That(result, Is.EqualTo(new Uri("path/file", UriKind.Relative)));
      Assert.That(result.IsAbsoluteUri, Is.False);
    }

    [Test,AutoData]
    public void Parse_treats_root_of_domain_uris_as_relative(RedirectUriParser sut)
    {
      // Act
      var result = sut.Parse("/root/path/file");

      // Assert
      Assert.That(result, Is.EqualTo(new Uri("/root/path/file", UriKind.Relative)));
      Assert.That(result.IsAbsoluteUri, Is.False);
    }

    [Test,AutoData]
    public void Parse_returns_null_when_uri_is_empty_string(RedirectUriParser sut)
    {
      // Act
      var result = sut.Parse(String.Empty);

      // Assert
      Assert.That(result, Is.Null);
    }

    [Test,AutoData]
    public void Parse_returns_null_when_uri_is_null(RedirectUriParser sut)
    {
      // Act
      var result = sut.Parse(null);

      // Assert
      Assert.That(result, Is.Null);
    }
  }
}
