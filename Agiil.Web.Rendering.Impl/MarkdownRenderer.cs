using System;
using CommonMark;

namespace Agiil.Web.Rendering
{
  public class MarkdownRenderer : IRendersMarkdownToHtml
  {
    public virtual string GetHtml(string markdown)
    {
      if(markdown == null) return null;
      return CommonMarkConverter.Convert(markdown);
    }
  }
}
