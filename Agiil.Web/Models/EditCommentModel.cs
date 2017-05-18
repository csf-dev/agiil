using System;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Models
{
  public class EditCommentModel : StandardPageModel
  {
    public CommentDto Comment { get; set; }

    public EditCommentSpecification Specification { get; set; }

    public EditCommentResponse Response { get; set; }

    public EditCommentModel()
    {
      Specification = new EditCommentSpecification();
    }
  }
}
