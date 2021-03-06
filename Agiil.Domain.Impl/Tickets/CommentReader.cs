﻿using System;
using CSF.ORM;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public class CommentReader : ICommentReader
  {
    readonly IEntityData commentRepo;

    public Comment Read(IIdentity<Comment> id)
    {
      if(ReferenceEquals(id, null))
        return null;
      
      return commentRepo.Get(id);
    }

    public CommentReader(IEntityData commentRepo)
    {
      if(commentRepo == null)
        throw new ArgumentNullException(nameof(commentRepo));
      this.commentRepo = commentRepo;
    }
  }
}
