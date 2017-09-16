using System;
using Agiil.BDD.Actions;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class ChangeTheTicketTitle : Performable
  {
    readonly string title;

    protected override string GetReport(INamed actor)
    => $"{actor.Name} changes the ticket title to '{title}'";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Clear.TheContentsOf(EditTicket.TitleInputBox));
      actor.Perform(Enter.TheText(title).Into(EditTicket.TitleInputBox));
    }

    public ChangeTheTicketTitle(string title)
    {
      this.title = title;
    }
  }
}
