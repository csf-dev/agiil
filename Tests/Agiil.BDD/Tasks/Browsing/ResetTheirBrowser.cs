using System;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Browsing
{
  public class ResetTheirBrowser : Performable
  {
    protected override string GetReport(INamed actor)
      => $"{actor.Name} resets their browser for the Agiil application.";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform<OpenTheHomePage>();
      actor.Perform(ClearTheirBrowser.Cookies());
      actor.Perform(ClearTheirBrowser.LocalStorage());
    }
  }
}
