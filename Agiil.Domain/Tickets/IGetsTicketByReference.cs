using System;
namespace Agiil.Domain.Tickets
{
  public interface IGetsTicketByReference
  {
    Ticket GetTicketByReference(string reference);
    Ticket GetTicketByReference(TicketReference reference);
  }
}
