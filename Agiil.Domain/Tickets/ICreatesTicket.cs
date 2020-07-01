using System;
using Agiil.Domain.Capabilities;
using Agiil.Domain.Projects;

namespace Agiil.Domain.Tickets
{
    [EnforceCapabilities]
    public interface ICreatesTicket
    {
        Ticket CreateTicket([RequireCapability(ProjectCapability.CreateTicket)] CreateTicketRequest request);
    }
}
