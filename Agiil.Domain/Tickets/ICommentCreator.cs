using System;
using Agiil.Domain.Capabilities;

namespace Agiil.Domain.Tickets
{
    [EnforceCapabilities]
    public interface ICommentCreator
    {
        CreateCommentResponse Create([RequireCapability(TicketCapability.AddComment)] CreateCommentRequest request);
    }
}
