using System;
namespace Agiil.Domain.Tickets
{
  public class TicketListRequest
  {
    public bool ShowClosedTickets { get; set; }

    public bool ShowOpenTickets { get; set; }

    public TicketListRequest()
    {
      ShowClosedTickets = false;
      ShowOpenTickets = true;
    }

    public static TicketListRequest CreateDefault()
    {
      return new TicketListRequest();
    }
  }
}
