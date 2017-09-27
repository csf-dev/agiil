using System;
namespace Agiil.Web.Rendering
{
  public class CommonMarkHtmlRenderer : IHtmlRenderer
  {
    public virtual string GetHtml(string markdown)
    {
      if(markdown == null) return null;
      return CommonMark.CommonMarkConverter.Convert(markdown);
    }
  }
}
