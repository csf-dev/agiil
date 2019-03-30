using System;
namespace Agiil.Domain.Activity
{
  public class GetWorklogResponse
  {
    public TicketWorkLog WorkLog { get; set; }

    public Tickets.Ticket Ticket { get; set; }

    public bool Success { get; set; }

    public bool TimeSpentIsInvalid { get; set; }

    public bool TicketNotFound { get; set; }
  }
}
