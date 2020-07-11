using System;
using Agiil.Domain.Capabilities;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
    public class CommentIdentityFromRequestProvider : IGetsTargetEntityIdentity<Comment, EditCommentRequest>,
                                                      IGetsTargetEntityIdentity<Comment, DeleteCommentRequest>
    {
        public IIdentity<Comment> GetTargetEntityIdentity(EditCommentRequest value)
            => value.CommentIdentity;

        public IIdentity<Comment> GetTargetEntityIdentity(DeleteCommentRequest value)
            => value.CommentId;
    }
}
