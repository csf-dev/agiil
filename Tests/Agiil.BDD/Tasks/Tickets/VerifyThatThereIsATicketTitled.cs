using System;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;
using FluentAssertions;

namespace Agiil.BDD.Tasks.Tickets
{
  public class VerifyThatThereIsATicketTitled : Performable
  {
    readonly string title;

    protected override string GetReport(INamed actor)
    => $"{actor} verifies that there is a ticket with the title '{title}'";

    protected override void PerformAs(IPerformer actor)
    {
      var tickets = actor.Perform(FindTickets.WithTheTitle(title));

      tickets.Elements.Should().NotBeEmpty("At least one ticket must exist");

      actor.Perform(TheVisibility.Of(tickets))
           .Should()
           .BeTrue("The ticket must visible.");
    }

    public VerifyThatThereIsATicketTitled(string title)
    {
      if(title == null)
        throw new ArgumentNullException(nameof(title));
      
      this.title = title;
    }
  }
}
