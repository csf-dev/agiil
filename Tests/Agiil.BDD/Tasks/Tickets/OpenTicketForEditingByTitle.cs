using System;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Tasks.Tickets
{
  public class OpenTicketForEditingByTitle : Performable
  {
    readonly string title;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} opens a ticket with the title '{title}' for editing";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(OpenTheTicket.Titled(title));
      actor.Perform<BeginEditingTheTicket>();
    }

    public OpenTicketForEditingByTitle(string title)
    {
      if(title == null)
        throw new ArgumentNullException(nameof(title));

      this.title = title;
    }
  }
}
