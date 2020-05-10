using System;
using CSF.Entities;
using CSF.ORM;

namespace Agiil.Domain.Tickets
{
    public class TicketReferenceProvider : IGetsTicketReference
    {
        readonly IEntityData data;

        public TicketReference GetTicketReference(IIdentity<Ticket> ticketId) => data.Get(ticketId)?.GetTicketReference();

        public TicketReferenceProvider(IEntityData data)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
