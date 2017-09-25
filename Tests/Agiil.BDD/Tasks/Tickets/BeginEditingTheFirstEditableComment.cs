using System;
using System.Linq;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class BeginEditingTheFirstEditableComment : Performable
  {
    protected override string GetReport(INamed actor) => $"{actor.Name} edits the first editable comment";

    protected override void PerformAs(IPerformer actor)
    {
      var links = actor.Perform(Elements.InThePageBody()
                                .ThatAre(TicketDetail.Comments.EditCommentLink)
                                .Called("the edit comment links"));
      actor.Perform(Click.On(links.Elements.First()));
      actor.Perform(Wait.Until(EditComment.EditCommentForm).IsVisible());
    }
  }
}
