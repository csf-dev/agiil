using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class DeleteCommentRequest
  {
    public IIdentity<Comment> CommentId { get; set; }
  }
}
