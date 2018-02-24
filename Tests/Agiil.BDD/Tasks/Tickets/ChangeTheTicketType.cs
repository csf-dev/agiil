using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class ChangeTheTicketType : Performable
  {
    readonly string type;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} changes the ticket type to '{type}'";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Select.Item(type).From(EditTicket.Type));
    }

    public ChangeTheTicketType(string type)
    {
      this.type = type;
    }
  }
}
