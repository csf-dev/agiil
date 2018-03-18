using System;
using System.Web;
using Agiil.Domain;

namespace Agiil.Web.Services
{
  public class RootOfTheRequestDomainUriProvider : IProvidesApplicationBaseUri
  {
    public Uri GetBaseUri()
    {
      var requestUri = GetRequestUri();
      var uriString = requestUri.GetLeftPart(UriPartial.Authority);
      return new Uri(uriString);
    }

    protected virtual Uri GetRequestUri()
    {
      var context = GetHttpContext();
      return context?.Request?.Url;
    }

    HttpContext GetHttpContext() => HttpContext.Current;
  }
}
