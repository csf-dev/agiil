using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Tickets
{
  public class RemoveAllOfTheLabels : Performable
  {
    protected override string GetReport(INamed actor)
      => $"{actor.Name} removes all of the existing labels";

    protected override void PerformAs(IPerformer actor)
    {
      var removeButtons = actor.Perform(Elements.InThePageBody().ThatAre(EditTicket.RemoveLabelButtons).Called("The remove buttons"));
      foreach(var button in removeButtons.Elements)
      {
        actor.Perform(Click.On(button));
      }
    }

    public static IPerformable FromTheTicket()
      => new RemoveAllOfTheLabels();
  }
}
