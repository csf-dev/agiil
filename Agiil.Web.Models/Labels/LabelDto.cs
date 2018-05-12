using System;
using System.Web;

namespace Agiil.Web.Models.Labels
{
  public class LabelDto
  {
    public string Name { get; set; }

    public string UrlEncodedName => HttpUtility.UrlEncode(Name);
  }
}
