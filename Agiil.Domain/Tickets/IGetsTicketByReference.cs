using System;
using Agiil.Domain.Capabilities;

namespace Agiil.Domain.Tickets
{
    [EnforceCapabilities]
    public interface IGetsTicketByReference
    {
        Ticket GetTicketByReference([RequireCapability(TicketCapability.View)] TicketReference reference);
    }
}
