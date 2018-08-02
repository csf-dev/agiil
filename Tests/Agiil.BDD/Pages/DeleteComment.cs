using System;
using CSF.Screenplay.Selenium.Models;

namespace Agiil.BDD.Pages
{
  public class DeleteComment : Page
  {
    long commentId;

    public override string GetName() => $"the delete-comment page for comment ID {commentId}";

    public override IUriProvider GetUriProvider() => new AppUri($"Comment/ConfirmDelete/{commentId}");

    public static ILocatorBasedTarget ConfirmButton
      => new ElementId("confirm_button", "the confirm delete button");

    public static ILocatorBasedTarget CancelButton
      => new ElementId("cancel_button", "the cancel deletion button");

    public DeleteComment(long commentId)
    {
      this.commentId = commentId;
    }
  }
}
