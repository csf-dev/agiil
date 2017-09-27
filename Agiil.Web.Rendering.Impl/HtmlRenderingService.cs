using System;
namespace Agiil.Web.Rendering
{
  public class HtmlRenderingService : IHtmlRenderer
  {
    readonly IMarkupSanitizer sanitizer;
    readonly IMarkdownConverter converter;

    public string GetHtml(string markdown)
    {
      var htmlMarkup = converter.GetHtml(markdown);
      return sanitizer.Sanitize(htmlMarkup);
    }

    public HtmlRenderingService(IMarkupSanitizer sanitizer, IMarkdownConverter converter)
    {
      if(converter == null)
        throw new ArgumentNullException(nameof(converter));
      if(sanitizer == null)
        throw new ArgumentNullException(nameof(sanitizer));
      
      this.converter = converter;
      this.sanitizer = sanitizer;
    }
  }
}
