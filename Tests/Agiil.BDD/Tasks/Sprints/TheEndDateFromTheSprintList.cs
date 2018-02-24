using System;
using Agiil.BDD.Pages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Tasks.Sprints
{
  public class TheEndDateFromTheSprintList : Question<DateTime>
  {
    readonly string sprintTitle;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} reads the end date from the sprint {sprintTitle}";

    protected override DateTime PerformAs(IPerformer actor)
    {
      var startDateText = actor.Perform(TheText.Of(SprintList.SprintEndDate(sprintTitle)));
      return DateTime.Parse(startDateText);
    }

    TheEndDateFromTheSprintList(string sprintTitle)
    {
      if(sprintTitle == null)
        throw new ArgumentNullException(nameof(sprintTitle));
      this.sprintTitle = sprintTitle;
    }

    public static IQuestion<DateTime> ForTheSprintTitle(string title)
      => new TheEndDateFromTheSprintList(title);
  }
}
