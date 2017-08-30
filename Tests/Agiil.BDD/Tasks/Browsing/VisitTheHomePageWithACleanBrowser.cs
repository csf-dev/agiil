using System;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Tasks.Browsing
{
  public class VisitTheHomePageWithACleanBrowser : Performable
  {
    protected override string GetReport(INamed actor)
      => $"{actor.Name} visits the Agiil application with a clean browser.";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform<ResetTheirBrowser>();
      actor.Perform<OpenTheHomePage>();
    }
  }
}
