using System;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Web.Models.Tickets
{
  public class EditCommentSpecification
  {
    public IIdentity<Comment> CommentId { get; set; }

    public string Body { get; set; }
  }
}
