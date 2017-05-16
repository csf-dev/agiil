using System;
namespace Agiil.Domain.Tickets
{
  public class CreateCommentResponse
  {
    public bool IsSuccess { get; set; }

    public bool BodyIsInvalid { get; set; }
  }
}
