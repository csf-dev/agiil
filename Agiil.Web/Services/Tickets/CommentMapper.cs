using System;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;
using CSF.Entities;

namespace Agiil.Web.Services.Tickets
{
  public class CommentMapper
  {
    public CommentDto Map(Comment comment)
    {
      if(comment == null)
        return null;

      var id = comment.GetIdentity();

      return new CommentDto
      {
        Id = (id != null)? (long) id.Value : default(long),
        Timestamp = comment.CreationTimestamp,
        LastEditTimestamp = comment.LastEditTimestamp,
        Author = comment.User.Username,
        Body = comment.Body,
      };
    }
  }
}
