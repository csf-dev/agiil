using System;
namespace Agiil.Web.Rendering
{
  /// <summary>
  /// A service which converts a markdown string into an HTML markup string.
  /// </summary>
  public interface IRendersMarkdownToHtml
  {
    /// <summary>
    /// Gets the HTML markup for the given markdown.
    /// </summary>
    /// <returns>The HTML markup.</returns>
    /// <param name="markdown">Markdown.</param>
    string GetHtml(string markdown);
  }
}
