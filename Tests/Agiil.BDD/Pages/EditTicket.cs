using System;
using CSF.Screenplay.Web.Models;

namespace Agiil.BDD.Pages
{
  public class EditTicket : Page
  {
    long ticketId;

    public override string GetName() => "the edit ticket page";

    public override IUriProvider GetUriProvider() => new AppUri($"Ticket/Edit/{ticketId}");

    public static ILocatorBasedTarget EditTicketForm => new ElementId("EditTicketForm", "the edit-ticket form");

    public static ILocatorBasedTarget TitleInputBox => new ElementId("Title", "the ticket title");

    public static ILocatorBasedTarget DescriptionInputBox => new ElementId("Description", "the ticket description");

    public static ILocatorBasedTarget SubmitButton => new ElementId("SubmitButton", "the submit button");

    public static ILocatorBasedTarget SubmissionFailedErrorMessage
      => new ElementId("SubmissionFailedMessage", "the error message indicating that the submission failed");

    public static ILocatorBasedTarget Sprint
      => new ElementId("SprintIdentity", "the ticket's sprint");

    public EditTicket(long ticketId)
    {
      this.ticketId = ticketId;
    }
  }
}
