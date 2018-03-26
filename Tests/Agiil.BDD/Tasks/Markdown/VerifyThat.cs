using System;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Models;

namespace Agiil.BDD.Tasks.Markdown
{
  public class VerifyThat
  {
    string text;
    IWebElementAdapter container;

    public static VerifyThat TheRenderedText(string text)
    {
      return new VerifyThat { text = text };
    }

    public VerifyThat Inside(IWebElementAdapter container)
    {
      this.container = container;
      return this;
    }

    public IPerformable IsDisplayedWithinTheTag(string tagName)
      => new VerifyThatTheTextHasTheCorrectFormatting(container, text, tagName);
  }
}
