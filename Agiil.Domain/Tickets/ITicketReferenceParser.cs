using System;
namespace Agiil.Domain.Tickets
{
  public interface ITicketReferenceParser
  {
    TicketReference ParseReferece(string reference);

    string CreateReference(Ticket ticket);

    string CreateReference(TicketReference reference);

    string CreateReference(string projectCode, long ticketNumber);
  }
}
