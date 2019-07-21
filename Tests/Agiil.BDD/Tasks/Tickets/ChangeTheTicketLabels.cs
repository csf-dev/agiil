using System;
using Agiil.BDD.Pages;
using Agiil.BDD.Tasks.Labels;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class ChangeTheTicketLabels : Performable
  {
    readonly string newLabels;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} changes the ticket labels to '{newLabels}'";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Wait.ForAtMost(5).Seconds().OrUntil(EditTicket.TicketLabelsInputBox).IsVisible());

      actor.Perform(RemoveAllOfTheLabels.FromTheTicket());
      actor.Perform(EnterTheLabels.Named(newLabels));
    }

    public ChangeTheTicketLabels(string newLabels)
    {
      this.newLabels = newLabels;
    }
  }
}
