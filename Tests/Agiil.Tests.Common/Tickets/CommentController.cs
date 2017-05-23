using System;
using Agiil.Web.Models;

namespace Agiil.Tests.Tickets
{
  public class CommentController : ICommentController
  {
    readonly Web.Controllers.CommentController webController;

    public void Add(AddCommentSpecification comment)
    {
      webController.Add(comment);
    }

    public void Edit(EditCommentSpecification comment)
    {
      webController.Edit(comment);
    }

    public CommentController(Web.Controllers.CommentController webController)
    {
      if(webController == null)
        throw new ArgumentNullException(nameof(webController));
      this.webController = webController;
    }
  }
}
