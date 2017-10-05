using System;
namespace Agiil.Web.Rendering
{
  public interface IMarkupSanitizer
  {
    string Sanitize(string markup);
  }
}
