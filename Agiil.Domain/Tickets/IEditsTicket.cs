using System;
using Agiil.Domain.Capabilities;

namespace Agiil.Domain.Tickets
{
    [EnforceCapabilities]
    public interface IEditsTicket
    {
        void Edit(Ticket ticket, [RequireCapability(TicketCapability.Edit)] EditTicketRequest request);
    }
}
