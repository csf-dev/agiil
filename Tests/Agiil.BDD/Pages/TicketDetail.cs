﻿using System;
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

    public static ILocatorBasedTarget EditTicketLink
      => new ElementId("EditTicketLink", "the edit ticket link");

    public static ILocatorBasedTarget CloseTicketButton
      => new ElementId("CloseTicket", "the close-ticket button");

    public static ILocatorBasedTarget ReopenTicketButton
      => new ElementId("ReopenTicket", "the reopen-ticket button");

    public static ILocatorBasedTarget TicketState
      => new ElementId("TicketState", "the ticket state");

    public TicketDetail(long ticketId)
    {
      this.ticketId = ticketId;
    }
  }
}
