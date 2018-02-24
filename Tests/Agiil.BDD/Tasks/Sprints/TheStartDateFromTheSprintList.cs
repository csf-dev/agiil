using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Sprints
{
  public class TheStartDateFromTheSprintList : Question<DateTime>
  {
    readonly string sprintTitle;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} reads the start date from the sprint {sprintTitle}";

    protected override DateTime PerformAs(IPerformer actor)
    {
      var startDateText = actor.Perform(TheText.Of(SprintList.SprintStartDate(sprintTitle)));
      return DateTime.Parse(startDateText);
    }

    TheStartDateFromTheSprintList(string sprintTitle)
    {
      if(sprintTitle == null)
        throw new ArgumentNullException(nameof(sprintTitle));
      this.sprintTitle = sprintTitle;
    }

    public static IQuestion<DateTime> ForTheSprintTitle(string title)
      => new TheStartDateFromTheSprintList(title);
  }
}
