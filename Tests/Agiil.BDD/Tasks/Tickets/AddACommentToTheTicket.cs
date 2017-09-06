using System;
using Agiil.BDD.Actions;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class AddACommentToTheTicket : Performable
  {
    readonly string commentText;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} adds a comment to the ticket reading '{commentText}'";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Clear.TheContentsOf(TicketDetail.AddCommentBody));
      actor.Perform(Enter.TheText(commentText).Into(TicketDetail.AddCommentBody));
      actor.Perform(Click.On(TicketDetail.AddCommentSubmitButton));
      actor.Perform(Wait.Until(TicketDetail.AddCommentFeedbackMessage).IsVisible());
    }

    AddACommentToTheTicket(string commentText)
    {
      this.commentText = commentText;
    }

    public static IPerformable WithTheText(string text)
    {
      return new AddACommentToTheTicket(text);
    }
  }
}
