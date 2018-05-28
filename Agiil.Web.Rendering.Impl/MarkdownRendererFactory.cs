using System;
namespace Agiil.Web.Rendering
{
  public class MarkdownRendererFactory
  {
    readonly Func<MarkdownRenderer> baseRendererCreator;
    readonly Func<IRendersMarkdownToHtml, SanitizingMarkdownRendererProxy> sanitisingProxyCreator;

    public IRendersMarkdownToHtml GetRenderer()
    {
      var baseRenderer = baseRendererCreator();
      var sanitisingProxy = sanitisingProxyCreator(baseRenderer);
      return sanitisingProxy;
    }

    public MarkdownRendererFactory(Func<MarkdownRenderer> baseRenderer,
                                   Func<IRendersMarkdownToHtml,SanitizingMarkdownRendererProxy> sanitisingProxy)
    {
      if(sanitisingProxy == null)
        throw new ArgumentNullException(nameof(sanitisingProxy));
      if(baseRenderer == null)
        throw new ArgumentNullException(nameof(baseRenderer));
      
      this.baseRendererCreator = baseRenderer;
      this.sanitisingProxyCreator = sanitisingProxy;
    }
  }
}
