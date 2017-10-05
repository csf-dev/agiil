using System;
namespace Agiil.Web.Rendering
{
  public interface IMarkdownConverter
  {
    string GetHtml(string markdown);
  }
}
