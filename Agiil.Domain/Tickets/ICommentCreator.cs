using System;
namespace Agiil.Domain.Tickets
{
  public interface ICommentCreator
  {
    CreateCommentResponse Create(CreateCommentRequest request);
  }
}
