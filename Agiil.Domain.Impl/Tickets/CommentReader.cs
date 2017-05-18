using System;
using CSF.Data.Entities;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class CommentReader : ICommentReader
  {
    readonly IRepository<Comment> commentRepo;

    public Comment Read(IIdentity<Comment> id)
    {
      if(ReferenceEquals(id, null))
        return null;
      
      return commentRepo.Get(id);
    }

    public CommentReader(IRepository<Comment> commentRepo)
    {
      if(commentRepo == null)
        throw new ArgumentNullException(nameof(commentRepo));
      this.commentRepo = commentRepo;
    }
  }
}
