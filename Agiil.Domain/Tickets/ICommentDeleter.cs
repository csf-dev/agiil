using System;
using Agiil.Domain.Capabilities;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
    [EnforceCapabilities]
    public interface ICommentDeleter
    {
        DeleteCommentResponse Delete([RequireCapability(CommentCapability.Delete)] DeleteCommentRequest request);
    }
}
