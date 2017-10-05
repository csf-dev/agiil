using System;
using Agiil.BDD.Actions;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class ChangeTheCommentText : Performable
  {
    readonly string newText;

    protected override string GetReport(INamed actor) => $"{actor.Name} changes the comment text to '{newText}'";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Clear.TheContentsOf(EditComment.CommentBody));
      actor.Perform(Enter.TheText(newText).Into(EditComment.CommentBody));
      actor.Perform(Navigate.ToAnotherPageByClicking(EditComment.SubmitButton));
    }

    ChangeTheCommentText(string newText)
    {
      if(newText == null)
        throw new ArgumentNullException(nameof(newText));

      this.newText = newText;
    }

    public static ChangeTheCommentText To(string newText) => new ChangeTheCommentText(newText);
  }
}
