using System;
using Agiil.Domain.Capabilities;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
    public class TicketIdentityFromCreateCommentRequestProvider : IGetsTargetEntityIdentity<Ticket, CreateCommentRequest>
    {
        public IIdentity<Ticket> GetTargetEntityIdentity(CreateCommentRequest value)
            => value.TicketId;
    }
}
