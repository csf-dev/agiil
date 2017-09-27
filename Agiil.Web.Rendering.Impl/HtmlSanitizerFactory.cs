using System;
using Ganss.XSS;

namespace Agiil.Web.Rendering
{
  public class HtmlSanitizerFactory
  {
    public HtmlSanitizer GetSanitizer() => new HtmlSanitizer();
  }
}
