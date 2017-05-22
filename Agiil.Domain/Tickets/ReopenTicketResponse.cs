using System;
namespace Agiil.Domain.Tickets
{
  public class ReopenTicketResponse : IIndictesSuccess
  {
    public bool IsSuccess => !(TicketNotFound || TicketAlreadyOpen);

    public bool TicketNotFound { get; set; }

    public bool TicketAlreadyOpen { get; set; }
  }
}
