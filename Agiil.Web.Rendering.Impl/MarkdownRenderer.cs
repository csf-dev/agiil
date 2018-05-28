using System;
using Markdig;

namespace Agiil.Web.Rendering
{
  public class MarkdownRenderer : IRendersMarkdownToHtml
  {
    readonly MarkdigPipelineFactory pipelineFactory;

    public virtual string GetHtml(string markdown)
    {
      if(markdown == null) return null;
      var pipeline = pipelineFactory.GetMarkdownPipeline();
      return Markdown.ToHtml(markdown, pipeline);
    }

    public MarkdownRenderer(MarkdigPipelineFactory pipelineFactory)
    {
      if(pipelineFactory == null)
        throw new ArgumentNullException(nameof(pipelineFactory));
      this.pipelineFactory = pipelineFactory;
    }
  }
}
