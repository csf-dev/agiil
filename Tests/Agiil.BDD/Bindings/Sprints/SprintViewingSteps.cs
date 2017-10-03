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
using System.Collections.Generic;

namespace Agiil.BDD.Bindings.Sprints
{
  [Binding]
  public class SprintViewingSteps
  {
    const string CurrentTicketTitlesKey = "The ticket titles";

    readonly IScreenplayScenario screenplay;
    readonly ScenarioContext context;

    [Given(@"Youssef has opened the sprint listing page")]
    public void GivenYoussefHasOpenedTheSprintListingPage()
    {
      var youssef = screenplay.GetYoussef();
      Given(youssef).WasAbleTo(OpenTheirBrowserOn.ThePage(SprintList.ForOpenSprints()));
    }

    [Given(@"Youssef was able to open the sprint titled '([^']+)'")]
    public void GivenYoussefViewsTheSprintTitled(string sprintTitle)
    {
      var youssef = screenplay.GetYoussef();
      Given(youssef).WasAbleTo(ViewTheSprintDetail.ForSprint(sprintTitle));
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

    [When(@"Youssef views the sprint titled '([^']+)'")]
    public void WhenYoussefViewsTheSprintTitled(string sprintTitle)
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(ViewTheSprintDetail.ForSprint(sprintTitle));
    }

    [When(@"Youssef reads the (open|closed) tickets in this sprint")]
    public void WhenYoussefReadsTheTicketsInThisSprint(string openOrClosed)
    {
      var youssef = screenplay.GetYoussef();
      var ticketTitles = When(youssef).AttemptsTo(ReadTheTicketTitlesFromTheCurrentSprint.WhichAre(openOrClosed));
      context.Set(ticketTitles, CurrentTicketTitlesKey);
    }

    [Then(@"Youssef should see the following tickets, in any order:")]
    public void ThenYoussefShouldSeeTheFollowingTicketsInAnyOrder(Table expectedTicketTitles)
    {
      var ticketTitles = context.Get<IReadOnlyList<string>>(CurrentTicketTitlesKey);
      if(ticketTitles == null)
        throw new InvalidOperationException("There must be a collection of ticket titles in the current context");

      var expectedTitles = expectedTicketTitles
        .Rows
        .Select(x => x.Values.Single())
        .ToArray();
      ticketTitles
        .Should()
        .BeEquivalentTo(expectedTitles, because: "the ticket titles should match");
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

    [Then(@"Youssef should see that the sprint has the following details")]
    public void ThenYoussefShouldSeeThatTheSprintHasTheFollowingDetails(Table table)
    {
      var expectedDetails = table.CreateInstance<SprintDetails>();
    
      var youssef = screenplay.GetYoussef();
      Then(youssef).Should(VerifyThatTheSprintDetailsMatch.TheExpectations(expectedDetails));
    }

    public SprintViewingSteps(IScreenplayScenario screenplay,
                              ScenarioContext context)
    {
      if(context == null)
        throw new ArgumentNullException(nameof(context));
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));

      this.screenplay = screenplay;
      this.context = context;
    }
  }
}
