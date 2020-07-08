using System;
using Agiil.Domain.Capabilities;
using Agiil.Domain.Tickets;

namespace Agiil.Domain.Activity
{
    [EnforceCapabilities]
    public interface IAddsWorkLogForTicket
    {
        AddWorklogResponse AddWorkLog([RequireCapability(TicketCapability.Edit)] AddWorkLogRequest request);
    }
}
