using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class EditCommentRequest
  {
    public IIdentity<Comment> CommentIdentity { get; set; }

    public string Body { get; set; }
  }
}
