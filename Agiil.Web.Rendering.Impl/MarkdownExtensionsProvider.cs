using System;
using System.Collections.Generic;
using System.Linq;
using Markdig;

namespace Agiil.Web.Rendering
{
  public class MarkdownExtensionsProvider
  {
    public IEnumerable<IMarkdownExtension> GetExtensions()
    {
      return Enumerable.Empty<IMarkdownExtension>();
    }
  }
}
