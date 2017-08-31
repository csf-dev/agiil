using System;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Tasks.Tickets
{
  public class ReadTheTicketSprintTitle : Question<string>
  {
    protected override string GetReport(INamed actor)
      => $"{actor.Name} reads the title of the sprint associated with the ticket"

    protected override string PerformAs(IPerformer actor)
    {
      throw new NotImplementedException();
    }
  }
}
