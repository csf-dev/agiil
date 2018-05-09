using System;
using Agiil.BDD.Pages;
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
      actor.Perform(Enter.TheText(newLabels).Into(EditTicket.TicketLabelsInputBox));
    }

    public ChangeTheTicketLabels(string newLabels)
    {
      this.newLabels = newLabels;
    }
  }
}
