using System;
using System.Linq;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class DeleteTheFirstDeletableComment : Performable
  {
    protected override string GetReport(INamed actor) => $"{actor.Name} deletes the first comment which is available for deletion";

    protected override void PerformAs(IPerformer actor)
    {
      var links = actor.Perform(Elements.InThePageBody()
                                .ThatAre(TicketDetail.Comments.DeleteCommentButton)
                                .Called("the delete comment buttons"));
      actor.Perform(Navigate.ToAnotherPageByClicking(links.Elements.First()));
      actor.Perform(Wait.Until(TicketDetail.TitleContent).IsVisible());
    }
  }
}
