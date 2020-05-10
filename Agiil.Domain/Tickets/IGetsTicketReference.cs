using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
    public interface IGetsTicketReference
    {
        TicketReference GetTicketReference(IIdentity<Ticket> ticketId);
    }
}
