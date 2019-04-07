using System;
namespace Agiil.Domain.Tickets
{
  public interface IParsesTicketReference
  {
    TicketReference ParseReferece(string reference);

    string CreateReference(IIdentifiesTicketByProjectAndNumber ticket);

    string CreateReference(string projectCode, long ticketNumber);
  }
}
