using System;
using Agiil.BDD.Tasks.Browsing;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Models;

namespace Agiil.BDD.Tasks
{
  public class Type
  {
    readonly string text;

    public static Type TheText(string text) => new Type(text);

    public IPerformable Into(ITarget target) => new TypeTheText(text, target);

    Type(string text)
    {
      this.text = text;
    }
  }
}
