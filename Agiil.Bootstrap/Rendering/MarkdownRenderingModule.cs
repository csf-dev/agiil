using System;
using System.Collections.Generic;
using System.Reflection;
using Agiil.Web.Rendering;
using Autofac;
using Ganss.XSS;

namespace Agiil.Bootstrap.Rendering
{
  public class MarkdownRenderingModule : NamespaceModule
  {
    protected override string Namespace => typeof(IRendersMarkdownToHtml).Namespace;

    protected override IEnumerable<Assembly> GetSearchAssemblies()
    {
      return new [] {
        typeof(IRendersMarkdownToHtml).Assembly,
        typeof(SanitizingMarkdownRendererProxy).Assembly,
      };
    }

    protected override IEnumerable<Type> TypesNotToRegisterAutomatically => new [] {
      typeof(SanitizingMarkdownRendererProxy),
      typeof(MarkdownRenderer),
    };

		protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);

      RegisterMarkdownRenderers(builder);

      builder
        .Register(CreateHtmlSanitizer)
        .AsSelf()
        .As<IHtmlSanitizer>();
    }

    void RegisterMarkdownRenderers(ContainerBuilder builder)
    {
      builder.RegisterType<MarkdownRenderer>();
      builder.RegisterType<SanitizingMarkdownRendererProxy>();
      builder.Register(CreateMarkdownRenderer);
    }

    IRendersMarkdownToHtml CreateMarkdownRenderer(IComponentContext ctx)
    {
      var factory = ctx.Resolve<MarkdownRendererFactory>();
      return factory.GetRenderer();
    }

    HtmlSanitizer CreateHtmlSanitizer(IComponentContext ctx)
    {
      var factory = ctx.Resolve<HtmlSanitizerFactory>();
      return factory.GetSanitizer();
    }
  }
}
