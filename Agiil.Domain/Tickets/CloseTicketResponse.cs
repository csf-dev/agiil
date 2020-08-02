using System;
namespace Agiil.Domain.Tickets
{
  public class CloseTicketResponse : IOpenCloseTicketResponse
    {
    public bool IsSuccess => !(TicketNotFound || TicketAlreadyClosed);

    public bool TicketNotFound { get; set; }

    public bool TicketAlreadyClosed { get; set; }
  }
}
