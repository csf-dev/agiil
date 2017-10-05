using System;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Tasks.Browsing
{
  public class VisitTheHomePage : Performable
  {
    protected override string GetReport(INamed actor)
      => $"{actor.Name} visits the Agiil application home page.";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform<OpenTheHomePage>();
    }
  }
}
