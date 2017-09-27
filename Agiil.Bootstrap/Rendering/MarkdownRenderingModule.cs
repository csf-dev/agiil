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
    protected override string Namespace => typeof(IHtmlRenderer).Namespace;

    protected override IEnumerable<Assembly> GetSearchAssemblies()
    {
      return new [] {
        typeof(IHtmlRenderer).Assembly,
        typeof(HtmlRenderingService).Assembly,
      };
    }

    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);

      builder
        .Register(CreateHtmlSanitizer)
        .AsSelf()
        .As<IHtmlSanitizer>();
    }

    HtmlSanitizer CreateHtmlSanitizer(IComponentContext ctx)
    {
      var factory = ctx.Resolve<HtmlSanitizerFactory>();
      return factory.GetSanitizer();
    }
  }
}
