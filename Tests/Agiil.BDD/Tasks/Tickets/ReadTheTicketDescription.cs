using System;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Tasks.Tickets
{
  public class ReadTheTicketDescription : Question<string>
  {
    protected override string GetReport(INamed actor) => $"{actor.Name} reads the ticket description"

    protected override string PerformAs(IPerformer actor)
    {
      throw new NotImplementedException();
    }
  }
}
