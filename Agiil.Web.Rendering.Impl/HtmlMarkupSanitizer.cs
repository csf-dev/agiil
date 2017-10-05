using System;
using Ganss.XSS;

namespace Agiil.Web.Rendering
{
  public class HtmlMarkupSanitizer : IMarkupSanitizer
  {
    readonly IHtmlSanitizer sanitizer;

    public string Sanitize(string markup)
    {
      if(markup == null) return null;
      return sanitizer.Sanitize(markup);
    }

    public HtmlMarkupSanitizer(IHtmlSanitizer sanitizer)
    {
      if(sanitizer == null)
        throw new ArgumentNullException(nameof(sanitizer));
      this.sanitizer = sanitizer;
    }
  }
}
