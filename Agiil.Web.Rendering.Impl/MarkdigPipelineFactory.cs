using System;
using Markdig;

namespace Agiil.Web.Rendering
{
  public class MarkdigPipelineFactory
  {
    public MarkdownPipeline GetMarkdownPipeline()
    {
      var builder = new MarkdownPipelineBuilder();

      return builder.Build();
    }
  }
}
