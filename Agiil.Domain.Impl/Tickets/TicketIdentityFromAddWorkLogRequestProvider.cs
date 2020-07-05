using System;
using Agiil.Domain.Activity;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
    public class TicketIdentityFromAddWorkLogRequestProvider : Capabilities.IGetsTargetEntityIdentity<Ticket, AddWorkLogRequest>
    {
        readonly IGetsTicketByReference ticketProvider;

        public IIdentity<Ticket> GetTargetEntityIdentity(AddWorkLogRequest value)
            => ticketProvider.GetTicketByReference(value.TicketReference)?.GetIdentity();

        public TicketIdentityFromAddWorkLogRequestProvider(IGetsTicketByReference ticketProvider)
        {
            this.ticketProvider = ticketProvider ?? throw new ArgumentNullException(nameof(ticketProvider));
        }
    }
}
