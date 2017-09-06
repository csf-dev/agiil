using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class CloseTheTicket : Performable
  {
    protected override string GetReport(INamed actor)
      => $"{actor.Name} closes the ticket";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Click.On(TicketDetail.CloseTicketButton));
      actor.Perform(Wait.Until(TicketDetail.ReopenTicketButton).IsVisible());
    }
  }
}
