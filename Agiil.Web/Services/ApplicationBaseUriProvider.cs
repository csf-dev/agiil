using System;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain;

namespace Agiil.Web.Services
{
  public class ApplicationBaseUriProvider : IProvidesApplicationBaseUri
  {
    readonly HttpRequestBase request;
    readonly UrlHelper urlHelper;

    public Uri GetBaseUri()
    {
      var rootOfDomain = request?.Url?.GetLeftPart(UriPartial.Authority);
      if(rootOfDomain == null) return null;

      if(urlHelper == null)
        return new Uri(rootOfDomain);

      var uriString = String.Concat(rootOfDomain.TrimEnd('/'), urlHelper.Content("~"));
      return new Uri(uriString);
    }

    public ApplicationBaseUriProvider(HttpRequestBase request, UrlHelper urlHelper)
    {
      this.request = request;
      this.urlHelper = urlHelper;
    }
  }
}
