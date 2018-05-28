using System;
using System.Collections.Generic;
using System.Reflection;
using Agiil.Web.Rendering;
using Agiil.Web.Rendering.MarkdownExtensions;

namespace Agiil.Bootstrap.Rendering
{
  public class MarkdownRenderingExtensionsModule : NamespaceModule
  {
    protected override string Namespace => typeof(AutoTicketLinkExtension).Namespace;

    protected override IEnumerable<Assembly> GetSearchAssemblies()
    {
      return new [] {
        typeof(IRendersMarkdownToHtml).Assembly,
        typeof(SanitizingMarkdownRendererProxy).Assembly,
      };
    }
  }
}
