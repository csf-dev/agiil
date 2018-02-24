using System;
using Agiil.BDD.Actions;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class ChangeTheTicketDescription : Performable
  {
    readonly string description;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} changes the ticket description to '{description}'";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Clear.TheContentsOf(EditTicket.DescriptionInputBox));
      actor.Perform(Enter.TheText(description).Into(EditTicket.DescriptionInputBox));
    }

    public ChangeTheTicketDescription(string description)
    {
      this.description = description;
    }
  }
}
