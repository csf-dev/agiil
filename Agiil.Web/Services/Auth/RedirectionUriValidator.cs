using System;
using Agiil.Domain;

namespace Agiil.Web.Services.Auth
{
  public class RedirectionUriValidator : IValidatesRedirectUrls
  {
    readonly IProvidesApplicationBaseUri baseUriProvider;

    public bool IsValid(string redirectUri)
    {
      if(String.IsNullOrEmpty(redirectUri)) return false;
      return IsValid(new Uri(redirectUri));
    }

    public bool IsValid(Uri redirectUri)
    {
      if(redirectUri == null) return false;
      if(!redirectUri.IsAbsoluteUri) return true;

      var redirectWithHost = GetUriWithHost(redirectUri);
      var appBaseUri = baseUriProvider.GetBaseUri();
      return appBaseUri.IsBaseOf(redirectWithHost);
    }

    Uri GetUriWithHost(Uri redirectUri)
    {
      if(!String.IsNullOrEmpty(redirectUri.Host))
        return redirectUri;

      var domainRoot = new Uri(baseUriProvider.GetBaseUri().GetLeftPart(UriPartial.Authority));
      return new Uri(domainRoot, redirectUri.OriginalString);
    }

    public RedirectionUriValidator(IProvidesApplicationBaseUri baseUriProvider)
    {
      if(baseUriProvider == null)
        throw new ArgumentNullException(nameof(baseUriProvider));
      this.baseUriProvider = baseUriProvider;
    }
  }
}
