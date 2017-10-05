using System;
namespace Agiil.Web.Rendering
{
  public interface IHtmlRenderer
  {
    string GetHtml(string markdown);
  }
}
