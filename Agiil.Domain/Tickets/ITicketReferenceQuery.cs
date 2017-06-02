using System;
namespace Agiil.Domain.Tickets
{
  public interface ITicketReferenceQuery
  {
    Ticket GetTicketByReference(string reference);
  }
}
