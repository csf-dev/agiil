using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class ChangeTheTicketSprint : Performable
  {
    readonly string title;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} moves the ticket to sprint '{title}'";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Deselect.EverythingFrom(EditTicket.Sprint));
      actor.Perform(Select.Item(title).From(EditTicket.Sprint));
    }

    public ChangeTheTicketSprint(string title)
    {
      this.title = title;
    }
  }
}
