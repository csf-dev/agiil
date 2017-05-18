using System;
namespace Agiil.Domain.Tickets
{
  public interface ICommentEditor
  {
    EditCommentResponse Edit(EditCommentRequest request);
  }
}
