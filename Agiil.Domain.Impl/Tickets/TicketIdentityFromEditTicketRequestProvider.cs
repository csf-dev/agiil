using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
    public class TicketIdentityFromEditTicketRequestProvider : Capabilities.IGetsTargetEntityIdentity<Ticket,EditTicketRequest>
    {
        public IIdentity<Ticket> GetTargetEntityIdentity(EditTicketRequest value)
            => value.Identity;
    }
}
