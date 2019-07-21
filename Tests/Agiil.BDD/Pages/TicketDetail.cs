using System;
using Agiil.BDD.PageComponents;
using CSF.Screenplay.Selenium.Models;

namespace Agiil.BDD.Pages
{
  public class TicketDetail : Page
  {
    readonly string ticketReference;
    static TicketCommentList comments = new TicketCommentList();

    public override string GetName() => $"the ticket detail page for ticket #{ticketReference}";

    public override IUriProvider GetUriProvider() => new AppUri($"Ticket/Index/{ticketReference}");

    public static ILocatorBasedTarget TitleContent
      => new ClassName("title_content", "the ticket title");

    public static ILocatorBasedTarget TicketType
    => new ClassName("ticket_type", "the ticket type");

    public static ILocatorBasedTarget DescriptionContent
      => new ClassName("description_content", "the ticket description");

    public static ILocatorBasedTarget SprintTitle
      => new ClassName("TicketSprintName", "the ticket's sprint title");

    public static ILocatorBasedTarget LabelNames
      => new CssSelector("ul.ticket_labels li .name", "the label names");

    public static ILocatorBasedTarget CommentBodies
      => new CssSelector("ol.comment_list .comment_content", "the comment texts");

    public static ILocatorBasedTarget EditTicketLink
      => new ElementId("EditTicketLink", "the edit ticket link");

    public static ILocatorBasedTarget CloseTicketButton
      => new ElementId("OpenCloseButton", "the close-ticket button");

    public static ILocatorBasedTarget ReopenTicketButton
      => new ElementId("OpenCloseButton", "the reopen-ticket button");

    public static ILocatorBasedTarget TicketState
      => new CssSelector(".open_close_ticket .ticket_state", "the ticket state");

    public static ILocatorBasedTarget TicketCreatorUsername
      => new ElementId("TicketCreatorUsername", "the ticket creator");

    public static ILocatorBasedTarget AddCommentBody
      => new ElementId("AddCommentBody", "the comment body");

    public static ILocatorBasedTarget AddCommentSubmitButton
      => new ElementId("AddCommentSubmit", "the add-comment button");

    public static ILocatorBasedTarget AddCommentFeedbackMessage
    => new ClassName("AddCommentFeedbackMessage", "the add-comment feedback message");

    public static ILocatorBasedTarget CommentDeletedFeedbackMessage
      => new ClassName("DeleteCommentFeedbackMessage", "the delete-comment feedback message");

    public static TicketCommentList Comments => comments;

    public TicketDetail(string ticketReference)
    {
      this.ticketReference = ticketReference;
    }
  }
}
