using System;
using Agiil.BDD.Models.Sprints;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.Selenium.Builders;
using Agiil.BDD.Pages;
using FluentAssertions;

namespace Agiil.BDD.Tasks.Sprints
{
  public class VerifyThatTheSprintDetailsMatch : Performable
  {
    readonly SprintDetails expectedDetails;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} verifies that the sprint details match expectations";

    protected override void PerformAs(IPerformer actor)
    {
      if(expectedDetails.Title != null)
      {
        actor.Perform(TheText.Of(SprintDetail.SprintName))
             .Should()
             .Be(expectedDetails.Title, because: "the title should match");
      }

      if(expectedDetails.StartDate != null)
      {
        var dateString = actor.Perform(TheText.Of(SprintDetail.StartDate));
        var date = DateTime.Parse(dateString);

        date.Should()
            .Be(expectedDetails.StartDate.Value, because: "the start date should match");
      }

      if(expectedDetails.EndDate != null)
      {
        var dateString = actor.Perform(TheText.Of(SprintDetail.EndDate));
        var date = DateTime.Parse(dateString);

        date.Should()
            .Be(expectedDetails.EndDate.Value, because: "the end date should match");
      }

      if(expectedDetails.Description != null)
      {
        actor.Perform(TheText.Of(SprintDetail.Description))
             .Should()
             .Be(expectedDetails.Description, because: "the description should match");
      }
    }

    public VerifyThatTheSprintDetailsMatch(SprintDetails expectedDetails)
    {
      if(expectedDetails == null)
        throw new ArgumentNullException(nameof(expectedDetails));
      this.expectedDetails = expectedDetails;
    }

    public static IPerformable TheExpectations(SprintDetails expected)
      => new VerifyThatTheSprintDetailsMatch(expected);
  }
}
