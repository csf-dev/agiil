using Agiil.Web.Rendering;
using Autofac;
using Ganss.XSS;

namespace Agiil.Bootstrap.Rendering
{
  public class MarkdownRenderingModule : Module
  {
		protected override void Load(ContainerBuilder builder)
    {
      builder.Register(CreateMarkdownRenderer);

      builder
        .Register(CreateHtmlSanitizer)
        .AsSelf()
        .As<IHtmlSanitizer>();
    }

    IRendersMarkdownToHtml CreateMarkdownRenderer(IComponentContext ctx)
      => ctx.Resolve<MarkdownRendererFactory>().GetRenderer();

    HtmlSanitizer CreateHtmlSanitizer(IComponentContext ctx)
      => ctx.Resolve<HtmlSanitizerFactory>().GetSanitizer();
  }
}
