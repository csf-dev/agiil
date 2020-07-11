using System;
using Agiil.Domain.Capabilities;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
    public class TicketIdentityFromTicketReferenceProvider : IGetsTargetEntityIdentity<Ticket, TicketReference>
    {
        readonly IGetsTicketByReference ticketProvider;

        public IIdentity<Ticket> GetTargetEntityIdentity(TicketReference value)
            => ticketProvider.GetTicketByReference(value)?.GetIdentity();

        public TicketIdentityFromTicketReferenceProvider(IGetsTicketByReference ticketProvider)
        {
            this.ticketProvider = ticketProvider ?? throw new ArgumentNullException(nameof(ticketProvider));
        }
    }
}
