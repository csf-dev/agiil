using System;
using CSF.Screenplay.Web.Models;

namespace Agiil.BDD.Pages
{
  public class TicketDetail : Page
  {
    long ticketId;

    public override string GetName() => $"the ticket detail page for ticket ID {ticketId}";

    public override IUriProvider GetUriProvider() => new AppUri($"Ticket/Index/{ticketId}");

    public static ILocatorBasedTarget DescriptionContent
      => new ClassName("description_content", "the ticket description");

    public static ILocatorBasedTarget SprintTitle
      => new ClassName("TicketSprintName", "the ticket's sprint title");

    public static ILocatorBasedTarget CommentBodies
      => new CssSelector("ol.comment_list .comment_content", "the comment texts");

    public TicketDetail(long ticketId)
    {
      this.ticketId = ticketId;
    }
  }
}
