using System;
using Agiil.Domain.Capabilities;

namespace Agiil.Domain.Tickets
{
    [EnforceCapabilities]
    public interface ICommentEditor
    {
        EditCommentResponse Edit([RequireCapability(CommentCapability.Edit)] EditCommentRequest request);
    }
}
