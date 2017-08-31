using System;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Tasks.Tickets
{
  public class OpenTicketByTitle : Performable
  {
    readonly string title;

    protected override string GetReport(INamed actor) => $"{actor.Name} opens a ticket with the title '{title}'";

    protected override void PerformAs(IPerformer actor)
    {
      throw new NotImplementedException();
    }

    public OpenTicketByTitle(string title)
    {
      if(title == null)
        throw new ArgumentNullException(nameof(title));

      this.title = title;
    }
  }
}
