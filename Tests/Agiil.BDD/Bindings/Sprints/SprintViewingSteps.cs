using System;
using static CSF.Screenplay.StepComposer;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using CSF.Screenplay;
using CSF.Screenplay.Web.Builders;
using Agiil.BDD.Pages;
using System.Linq;
using FluentAssertions;
using Agiil.BDD.Tasks.Sprints;
using Agiil.BDD.Models.Sprints;

namespace Agiil.BDD.Bindings.Sprints
{
  [Binding]
  public class SprintViewingSteps
  {
    readonly IScreenplayScenario screenplay;

    [Given(@"Youssef has opened the sprint listing page")]
    public void GivenYoussefHasOpenedTheSprintListingPage()
    {
      var youssef = screenplay.GetYoussef();
      Given(youssef).WasAbleTo(OpenTheirBrowserOn.ThePage(SprintList.ForOpenSprints()));
    }

    [When(@"Youssef opens the sprint listing page")]
    public void WhenYoussedOpensTheSprintListingPage()
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(OpenTheirBrowserOn.ThePage(SprintList.ForOpenSprints()));
    }

    [When(@"Youssef opens the sprint listing page for closed sprints")]
    public void WhenYoussedOpensTheSprintListingPageForClosedSprints()
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(OpenTheirBrowserOn.ThePage(SprintList.ForClosedSprints()));
    }

    [Then(@"Youssef should see the following sprints, in order")]
    public void ThenYoussefShouldSeeTheSprintsInOrder(Table expectedSprintNamesTable)
    {
      var expectedSprintNames = expectedSprintNamesTable
        .Rows
        .Select(x => x.Values.Single())
        .ToArray();

      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(TheText.OfAll(SprintList.SprintNames))
                   .Should()
                   .ContainInOrder(expectedSprintNames, because: "The displayed sprints should match the expectation");
    }

    [Then(@"Youssef should see the following sprints")]
    public void ThenYoussefShouldSeeTheSprints(Table expectedSprintNamesTable)
    {
      var expectedSprintNames = expectedSprintNamesTable
        .Rows
        .Select(x => x.Values.Single())
        .ToArray();

      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(TheText.OfAll(SprintList.SprintNames))
                   .Should()
                   .Contain(expectedSprintNames, because: "The displayed sprints should match the expectation");
    }

    [Then(@"Youssef should see that the sprint titled '([^']*)' starts on (\d{4}-\d{1,2}-\d{1,2})")]
    public void ThenYoussefShouldVerifyTheSprintStartDate(string sprintTitle, string dateString)
    {
      var expected = DateTime.Parse(dateString);

      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(TheStartDateFromTheSprintList.ForTheSprintTitle(sprintTitle))
                   .Should()
                   .Be(expected, because: "the sprint start date should match");
    }

    [Then(@"Youssef should see that the sprint titled '([^']*)' ends on (\d{4}-\d{1,2}-\d{1,2})")]
    public void ThenYoussefShouldVerifyTheSprintEndDate(string sprintTitle, string dateString)
    {
      var expected = DateTime.Parse(dateString);

      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(TheEndDateFromTheSprintList.ForTheSprintTitle(sprintTitle))
                   .Should()
                   .Be(expected, because: "the sprint end date should match");
    }

    [When(@"Youssef views the sprint titled '([^']+)'")]
    public void WhenYoussefViewsTheSprintTitled(string sprintTitle)
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(ViewTheSprintDetail.ForSprint(sprintTitle));
    }

    [Then(@"Youssef should see that the sprint has the following details")]
    public void ThenYoussefShouldSeeThatTheSprintHasTheFollowingDetails(Table table)
    {
      var expectedDetails = table.CreateInstance<SprintDetails>();
    
      var youssef = screenplay.GetYoussef();
      Then(youssef).Should(VerifyThatTheSprintDetailsMatch.TheExpectations(expectedDetails));
    }

    public SprintViewingSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));

      this.screenplay = screenplay;
    }
  }
}
