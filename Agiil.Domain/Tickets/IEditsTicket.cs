using System;
namespace Agiil.Domain.Tickets
{
  public interface IEditsTicket
  {
    void Edit(Ticket ticket, EditTicketRequest request);
  }
}
