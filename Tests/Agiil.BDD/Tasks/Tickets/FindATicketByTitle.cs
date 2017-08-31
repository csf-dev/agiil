using System;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Tasks.Tickets
{
  public class FindATicketByTitle : Question<bool>
  {
    readonly string title;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} attempts to find a ticket with the title '{title}'";

    protected override bool PerformAs(IPerformer actor)
    {
      throw new System.NotImplementedException();
    }

    public FindATicketByTitle(string title)
    {
      if(title == null)
        throw new ArgumentNullException(nameof(title));
      this.title = title;
    }
  }
}
