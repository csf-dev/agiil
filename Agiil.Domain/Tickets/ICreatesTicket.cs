using System;

namespace Agiil.Domain.Tickets
{
  public interface ICreatesTicket
  {
    Ticket CreateTicket(CreateTicketRequest request);
  }
}
