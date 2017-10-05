using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class ReadTheTicketSprintTitle : Question<string>
  {
    protected override string GetReport(INamed actor)
      => $"{actor.Name} reads the title of the sprint associated with the ticket";

    protected override string PerformAs(IPerformer actor)
    {
      return actor.Perform(TheText.Of(TicketDetail.SprintTitle));
    }
  }
}
