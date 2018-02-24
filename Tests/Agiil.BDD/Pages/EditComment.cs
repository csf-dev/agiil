using System;
using CSF.Screenplay.Selenium.Models;

namespace Agiil.BDD.Pages
{
  public class EditComment : Page
  {
    readonly long commentId;

    public override string GetName() => $"the edit comment page for comment ID {commentId}";

    public override IUriProvider GetUriProvider() => new AppUri($"Comment/Edit/{commentId}");

    public static ILocatorBasedTarget EditCommentForm => new ElementId("EditComment", "the edit comment form");

    public static ILocatorBasedTarget CommentBody => new ElementId("Body", "the comment text");

    public static ILocatorBasedTarget SubmitButton => new ElementId("Submit", "the submit button");

    public static ILocatorBasedTarget EditCommentFailureMessage => new ElementId("EditFailureMessage",
                                                                                 "an editing failure message");

    EditComment(long commentId)
    {
      this.commentId = commentId;
    }

    public static EditComment ForCommentId(long commentId) => new EditComment(commentId);
  }
}
