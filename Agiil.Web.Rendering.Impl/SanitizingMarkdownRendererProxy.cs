using System;
namespace Agiil.Web.Rendering
{
  public class SanitizingMarkdownRendererProxy : IRendersMarkdownToHtml
  {
    readonly ISanitizesHtmlMarkup sanitizer;
    readonly IRendersMarkdownToHtml proxiedRenderer;

    public string GetHtml(string markdown)
    {
      var htmlMarkup = proxiedRenderer.GetHtml(markdown);
      return sanitizer.Sanitize(htmlMarkup);
    }

    public SanitizingMarkdownRendererProxy(ISanitizesHtmlMarkup sanitizer, IRendersMarkdownToHtml proxiedRenderer)
    {
      if(proxiedRenderer == null)
        throw new ArgumentNullException(nameof(proxiedRenderer));
      if(sanitizer == null)
        throw new ArgumentNullException(nameof(sanitizer));
      
      this.proxiedRenderer = proxiedRenderer;
      this.sanitizer = sanitizer;
    }
  }
}
