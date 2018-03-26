using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Sprints
{
  public class BeginEditingTheSprint : Performable
  {
    readonly string sprintTitle;

    protected override string GetReport(INamed actor) => $"{actor.Name} begins editing the sprint {sprintTitle}";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(ViewTheSprintDetail.ForSprint(sprintTitle));
      actor.Perform(Navigate.ToAnotherPageByClicking(SprintDetail.EditLink));
      actor.Perform(Wait.Until(EditSprint.SprintName).IsVisible());
    }

    BeginEditingTheSprint(string sprintTitle)
    {
      if(sprintTitle == null)
        throw new ArgumentNullException(nameof(sprintTitle));
      this.sprintTitle = sprintTitle;
    }

    public static IPerformable Titled(string title) => new BeginEditingTheSprint(title);
  }
}
