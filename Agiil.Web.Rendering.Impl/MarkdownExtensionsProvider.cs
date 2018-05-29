using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Web.Rendering.MarkdownExtensions;
using Markdig;

namespace Agiil.Web.Rendering
{
  public class MarkdownExtensionsProvider
  {
    readonly Func<AutoTicketLinkExtension> autoTicketLinkExtension;

    public IEnumerable<IMarkdownExtension> GetExtensions()
    {
      return new [] {
        autoTicketLinkExtension(),
      };
    }

    public MarkdownExtensionsProvider(Func<AutoTicketLinkExtension> autoTicketLinkExtension)
    {
      if(autoTicketLinkExtension == null)
        throw new ArgumentNullException(nameof(autoTicketLinkExtension));
      this.autoTicketLinkExtension = autoTicketLinkExtension;
    }
  }
}
