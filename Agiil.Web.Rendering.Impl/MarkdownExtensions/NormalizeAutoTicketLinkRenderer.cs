using System;
using Markdig.Renderers;
using Markdig.Renderers.Normalize;
using Markdig.Syntax;

namespace Agiil.Web.Rendering.MarkdownExtensions
{
  public class NormalizeAutoTicketLinkRenderer : NormalizeObjectRenderer<TicketLinkInline>
  {
    public override bool Accept(RendererBase renderer, MarkdownObject obj)
    {
      if (base.Accept(renderer, obj))
      {
        var normalizeRenderer = renderer as NormalizeRenderer;
        var link = obj as TicketLinkInline;

        return normalizeRenderer != null && link != null && !normalizeRenderer.Options.ExpandAutoLinks && link.IsAutoLink;
      }
      else
      {
        return false;
      }
    }

    protected override void Write(NormalizeRenderer renderer, TicketLinkInline obj)
    {
      renderer.Write(obj.Url);
    }
  }
}
