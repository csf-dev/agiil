using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Web.Builders;

namespace Agiil.BDD.Tasks.Sprints
{
  public class ViewTheSprintDetail : Performable
  {
    readonly string sprintTitle;

    protected override string GetReport(INamed actor) => $"{actor.Name} opens {sprintTitle}";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(OpenTheirBrowserOn.ThePage(SprintList.ForOpenSprints()));
      actor.Perform(Wait.Until(SprintList.SprintListTable).IsVisible());
      actor.Perform(Click.On(SprintList.TheSprintNamed(sprintTitle)));
      actor.Perform(Wait.Until(SprintDetail.SprintName).IsVisible());
    }

    ViewTheSprintDetail(string sprintTitle)
    {
      if(sprintTitle == null)
        throw new ArgumentNullException(nameof(sprintTitle));

      this.sprintTitle = sprintTitle;
    }

    public static IPerformable ForSprint(string sprintTitle)
      => new ViewTheSprintDetail(sprintTitle);
  }
}
