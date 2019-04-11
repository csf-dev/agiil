using System;
namespace Agiil.Domain.Tickets
{
  public interface IParsesTicketReference
  {
    TicketReference ParseReferece(string reference);

    TicketReference GetReference(IIdentifiesTicketByProjectAndNumber ticket);

    TicketReference GetReference(string projectCode, long ticketNumber);
  }
}
