using System;
using Agiil.Domain;

namespace Agiil.Web.Services.Auth
{
  public class RedirectionUriValidator : IValidatesRedirectUrls
  {
    readonly IProvidesApplicationBaseUri baseUriProvider;
    readonly RedirectUriParser uriParser;

    public bool IsValid(string redirectUri)
    {
      var uri = uriParser.Parse(redirectUri);
      if(uri == null) return false;

      return IsValid(uri);
    }

    public bool IsValid(Uri redirectUri)
    {
      if(redirectUri == null) return false;

      var redirectWithHost = GetUriWithHost(redirectUri);
      var appBaseUri = baseUriProvider.GetBaseUri();
      return appBaseUri.IsBaseOf(redirectWithHost);
    }

    Uri GetUriWithHost(Uri redirectUri)
    {
      if(redirectUri.IsAbsoluteUri)
        return redirectUri;

      var domainRoot = new Uri(baseUriProvider.GetBaseUri().GetLeftPart(UriPartial.Authority));
      return new Uri(domainRoot, redirectUri.OriginalString);
    }

    public RedirectionUriValidator(IProvidesApplicationBaseUri baseUriProvider)
    {
      if(baseUriProvider == null)
        throw new ArgumentNullException(nameof(baseUriProvider));
      this.baseUriProvider = baseUriProvider;
      uriParser = new RedirectUriParser();
    }
  }
}
