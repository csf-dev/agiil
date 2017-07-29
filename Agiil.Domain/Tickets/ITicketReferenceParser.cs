using System;
namespace Agiil.Domain.Tickets
{
  public interface ITicketReferenceParser
  {
    TicketReference ParseReferece(string reference);

    string CreateReference(IIdentifiesTicketByProjectAndNumber ticket);

    string CreateReference(string projectCode, long ticketNumber);
  }
}
