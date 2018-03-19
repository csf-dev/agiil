using System;
using System.Text.RegularExpressions;

namespace Agiil.Web.Services.Auth
{
  public class RedirectUriParser
  {
    const string AbsolutePattern = "^(?:[a-zA-Z0-9_-]+:)?//";
    static readonly Regex AbsoluteUriMatcher = new Regex(AbsolutePattern, RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public Uri Parse(string uriString)
    {
      if(String.IsNullOrEmpty(uriString)) return null;

      if(AbsoluteUriMatcher.IsMatch(uriString)) return new Uri(uriString, UriKind.Absolute);
      return new Uri(uriString, UriKind.Relative);
    }
  }
}
