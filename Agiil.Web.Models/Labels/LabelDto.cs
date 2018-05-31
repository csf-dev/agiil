using System;
using System.Web;

namespace Agiil.Web.Models.Labels
{
  public class LabelDto
  {
    public string Name { get; set; }

    public string UrlEncodedName
    {
      get {
        if(Name == null) return null;

        // #AG169 - UrlEncode is replacing spaces with plus characters,
        // but that's only good for query strings, not path strings.
        return HttpUtility.UrlEncode(Name).Replace("+", "%20");
      }
    }
  }
}
