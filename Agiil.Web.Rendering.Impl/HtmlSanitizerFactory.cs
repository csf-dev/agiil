using System;
using Ganss.XSS;

namespace Agiil.Web.Rendering
{
  public class HtmlSanitizerFactory
  {
    public HtmlSanitizer GetSanitizer()
    {
      var sanitizer = new HtmlSanitizer();

      sanitizer.AllowedAttributes.Add("class");

      return sanitizer;
    }
  }
}
