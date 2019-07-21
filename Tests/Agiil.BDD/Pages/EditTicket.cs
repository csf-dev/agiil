using System;
using CSF.Screenplay.Selenium.Models;

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

    public static ILocatorBasedTarget TicketLabelsInputBox => new ElementId("Labels_input", "the ticket labels");

    public static ILocatorBasedTarget ExistingLabelList
    => new CssSelector(".LabelChooser .LabelList", "the existing label list");

    public static ILocatorBasedTarget RemoveLabelButtons
      => new CssSelector(".LabelChooser .LabelList button", "the remove label buttons");

    public static ILocatorBasedTarget SubmitButton => new ElementId("SubmitButton", "the submit button");

    public static ILocatorBasedTarget SubmissionFailedErrorMessage
      => new ElementId("SubmissionFailedMessage", "the error message indicating that the submission failed");

    public static ILocatorBasedTarget Sprint
      => new ElementId("SprintIdentity", "the ticket's sprint");

    public static ILocatorBasedTarget Type
    => new ElementId("TicketTypeIdentity", "the ticket's type");

    public EditTicket(long ticketId)
    {
      this.ticketId = ticketId;
    }
  }
}
