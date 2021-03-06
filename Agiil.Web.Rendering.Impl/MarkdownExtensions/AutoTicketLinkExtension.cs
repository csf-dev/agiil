﻿using System;
using Markdig;
using Markdig.Renderers;
using Markdig.Renderers.Html;
using Markdig.Renderers.Normalize;
using Markdig.Renderers.Normalize.Inlines;
using Markdig.Syntax;

namespace Agiil.Web.Rendering.MarkdownExtensions
{
  public class AutoTicketLinkExtension : IMarkdownExtension
  {
    readonly Func<AutoTicketLinkParser> autoTicketLinkParserCreator;
    readonly Func<NormalizeAutoTicketLinkRenderer> normalizeAutoTicketLinkRendererCreator;

    public void Setup(MarkdownPipelineBuilder pipeline)
    {
      AddInlineParser(pipeline);
    }

    void AddInlineParser(MarkdownPipelineBuilder pipeline)
    {
      if (pipeline.InlineParsers.Contains<AutoTicketLinkParser>()) return;

      var parser = autoTicketLinkParserCreator();
      pipeline.InlineParsers.Insert(0, parser);
    }

    public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
    {
      var normalizeRenderer = renderer as NormalizeRenderer;
      if(normalizeRenderer == null || normalizeRenderer.ObjectRenderers.Contains<NormalizeAutoTicketLinkRenderer>())
        return;

      var autoTicketLinkRenderer = normalizeAutoTicketLinkRendererCreator();
      normalizeRenderer.ObjectRenderers.InsertBefore<LinkInlineRenderer>(autoTicketLinkRenderer);
    }

    public AutoTicketLinkExtension(Func<AutoTicketLinkParser> autoTicketLinkParserCreator,
                                   Func<NormalizeAutoTicketLinkRenderer> normalizeAutoTicketLinkRendererCreator)
    {
      if(normalizeAutoTicketLinkRendererCreator == null)
        throw new ArgumentNullException(nameof(normalizeAutoTicketLinkRendererCreator));
      if(autoTicketLinkParserCreator == null)
        throw new ArgumentNullException(nameof(autoTicketLinkParserCreator));
      
      this.autoTicketLinkParserCreator = autoTicketLinkParserCreator;
      this.normalizeAutoTicketLinkRendererCreator = normalizeAutoTicketLinkRendererCreator;
    }
  }
}
