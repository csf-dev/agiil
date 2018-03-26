using System;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;
using FluentAssertions;

namespace Agiil.BDD.Tasks.Tickets
{
  public class VerifyThatThereIsNotATicketTitled : Performable
  {
    readonly string title;

    protected override string GetReport(INamed actor)
      => $"{actor} verifies that there is not a ticket with the title '{title}'";

    protected override void PerformAs(IPerformer actor)
    {
      var tickets = actor.Perform(FindTickets.WithTheTitle(title));

      tickets.Elements.Should().BeEmpty("The ticket must not be found");
    }

    public VerifyThatThereIsNotATicketTitled(string title)
    {
      if(title == null)
        throw new ArgumentNullException(nameof(title));

      this.title = title;
    }
  }
}
