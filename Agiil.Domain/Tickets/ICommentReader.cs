using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public interface ICommentReader
  {
    Comment Read(IIdentity<Comment> id);
  }
}
