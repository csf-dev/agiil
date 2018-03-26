using System;
using System.Web;
using System.Web.Mvc;
using Agiil.Domain;

namespace Agiil.Web.Services
{
  public class ApplicationBaseUriProvider : IProvidesApplicationBaseUri
  {
    readonly Uri requestUri;
    readonly UrlHelper urlHelper;

    public Uri GetBaseUri()
    {
      if(requestUri == null) return null;

      var rootOfDomain = requestUri.GetLeftPart(UriPartial.Authority);

      if(urlHelper == null)
        return new Uri(rootOfDomain);

      var uriString = String.Concat(rootOfDomain.TrimEnd('/'), urlHelper.Content("~"));
      return new Uri(uriString);
    }

    public ApplicationBaseUriProvider(Uri requestUri, UrlHelper urlHelper)
    {
      this.requestUri = requestUri;
      this.urlHelper = urlHelper;
    }

    static HttpRequest GetHttpRequest() => HttpContext.Current?.Request;

    static Uri GetRequestUri() => GetHttpRequest()?.Url;

    static UrlHelper GetUrlHelper()
    {
      var requestContext = GetHttpRequest()?.RequestContext;
      if(requestContext == null) return null;
      return new UrlHelper(requestContext);
    }

    public static ApplicationBaseUriProvider CreateFromHttpContext()
      => new ApplicationBaseUriProvider(GetRequestUri(), GetUrlHelper());
  }
}
