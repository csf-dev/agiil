using System;
using Markdig;

namespace Agiil.Web.Rendering
{
  public class MarkdigPipelineFactory
  {
    readonly MarkdownExtensionsProvider extensionsProvider;

    public MarkdownPipeline GetMarkdownPipeline()
    {
      var builder = new MarkdownPipelineBuilder();

      var extensions = extensionsProvider.GetExtensions();
      foreach(var extension in extensions)
      {
        builder.Use(extension);
      }

      return builder.Build();
    }

    public MarkdigPipelineFactory(MarkdownExtensionsProvider extensionsProvider)
    {
      if(extensionsProvider == null)
        throw new ArgumentNullException(nameof(extensionsProvider));
      this.extensionsProvider = extensionsProvider;
    }
  }
}
