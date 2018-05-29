using System;
using Markdig.Syntax.Inlines;

namespace Agiil.Web.Rendering.MarkdownExtensions
{
  public class TicketLinkInline : LinkInline
  {
    public TicketLinkInline() {}

    public TicketLinkInline(string url, string title) : base(url, title) {}
  }
}
