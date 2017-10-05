using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class SubmitTheEditedTicket : Performable
  {
    protected override string GetReport(INamed actor)
      => $"{actor.Name} submits the edits to the ticket";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Navigate.ToAnotherPageByClicking(EditTicket.SubmitButton));
    }
  }
}
