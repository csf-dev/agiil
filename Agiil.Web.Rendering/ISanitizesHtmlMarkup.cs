using System;
namespace Agiil.Web.Rendering
{
  /// <summary>
  /// A service which sanitises HTML markup and ensures that it is safe to render in an end user's web browser.
  /// </summary>
  public interface ISanitizesHtmlMarkup
  {
    /// <summary>
    /// Gets a sanitised version of the specified HTML markup.
    /// </summary>
    /// <returns>The sanitized markup.</returns>
    /// <param name="markup">Markup.</param>
    string Sanitize(string markup);
  }
}
