using System;
using CSF.Screenplay.Selenium.Models;

namespace Agiil.BDD.Pages
{
  public class CreateNewTicket : Page
  {
    public override string GetName() => "the create-ticket page";

    public override IUriProvider GetUriProvider() => new AppUri("NewTicket");

    public static ILocatorBasedTarget TicketTitle = new ElementId("Title", "the ticket title");

    public static ILocatorBasedTarget TicketDescription = new ElementId("Description", "the ticket description");

    public static ILocatorBasedTarget TicketLabels = new ElementId("Labels", "the ticket labels");

    public static ILocatorBasedTarget TicketSprint = new ElementId("SprintIdentity", "the ticket sprint");

    public static ILocatorBasedTarget TicketType = new ElementId("TicketTypeIdentity", "the ticket type");

    public static ILocatorBasedTarget CreateButton = new ElementId("CreateTicket", "the create ticket button");

    public static ILocatorBasedTarget CreationSuccessMessage = new ElementId("ticket_creation_success_feedback",
                                                                             "a ticket-creation success message");

    public static ILocatorBasedTarget CreationFailureMessage = new ElementId("ticket_creation_failure_feedback",
                                                                             "a ticket-creation failure message");
  }
}
