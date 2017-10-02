using System;
using CSF.Entities;

namespace Agiil.Domain.Tickets
{
  public interface ICommentDeleter
  {
    DeleteCommentResponse Delete(DeleteCommentRequest request);
  }
}
