using System;
namespace Agiil.Web.Models
{
  public class EditCommentResponse
  {
    public bool UserDoesNotHavePermission { get; set; }

    public bool BodyIsInvalid { get; set; }

    public bool Success { get; set; }
  }
}
