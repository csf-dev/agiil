using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class ReopenTheTicket : Performable
  {
    protected override string GetReport(INamed actor)
    => $"{actor.Name} reopens the ticket";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Navigate.ToAnotherPageByClicking(TicketDetail.ReopenTicketButton));
      actor.Perform(Wait.Until(TicketDetail.CloseTicketButton).IsVisible());
    }
  }
}
