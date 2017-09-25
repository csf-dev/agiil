using System;
using System.Linq;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;
using FluentAssertions;

namespace Agiil.BDD.Tasks.Tickets
{
  public class OpenTicketDetailByTitle : Performable
  {
    readonly string title;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} opens a ticket with the title '{title}'";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(OpenTheirBrowserOn.ThePage<TicketList>());

      var ticket = actor.Perform(FindTickets.WithTheTitle(title))
                        .Elements
                        .FirstOrDefault();

      ticket.Should().NotBeNull("The ticket must exist");

      var ticketLink = actor.Perform(Elements.In(ticket).ThatAre(TicketList.TicketLink)
                                     .Called($"the hyperlink for ticket '{title}'"));

      actor.Perform(Navigate.ToAnotherPageByClicking(ticketLink));
      actor.Perform(Wait.Until(TicketDetail.TitleContent).IsVisible());
    }

    public OpenTicketDetailByTitle(string title)
    {
      if(title == null)
        throw new ArgumentNullException(nameof(title));

      this.title = title;
    }
  }
}
