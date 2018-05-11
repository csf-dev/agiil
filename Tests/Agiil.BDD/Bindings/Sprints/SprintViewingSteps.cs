using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.BDD.Models.Sprints;
using Agiil.BDD.Pages;
using Agiil.BDD.Personas;
using Agiil.BDD.Tasks.Sprints;
using CSF.Screenplay;
using CSF.Screenplay.Selenium.Builders;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Sprints
{
  [Binding]
  public class SprintViewingSteps
  {
    const string CurrentTicketTitlesKey = "The ticket titles";

    readonly ICast cast;
    readonly IStage stage;
    readonly ScenarioContext context;

    [Given(@"Youssef has opened the sprint listing page")]
    public void GivenYoussefHasOpenedTheSprintListingPage()
    {
      var youssef = cast.Get<Youssef>();
      stage.ShineTheSpotlightOn(youssef);
      Given(youssef).WasAbleTo(OpenTheirBrowserOn.ThePage(SprintList.ForOpenSprints()));
    }

    [Given(@"Youssef was able to open the sprint titled '([^']+)'")]
    public void GivenYoussefViewsTheSprintTitled(string sprintTitle)
    {
      var youssef = cast.Get<Youssef>();
      stage.ShineTheSpotlightOn(youssef);
      Given(youssef).WasAbleTo(ViewTheSprintDetail.ForSprint(sprintTitle));
    }

    [When(@"Youssef opens the sprint listing page")]
    public void WhenYoussefOpensTheSprintListingPage()
    {
      var youssef = cast.Get<Youssef>();
      stage.ShineTheSpotlightOn(youssef);
      When(youssef).AttemptsTo(OpenTheirBrowserOn.ThePage(SprintList.ForOpenSprints()));
    }

    [When(@"(?:he|she|they) opens? the sprint listing page")]
    public void WhenTheyOpenTheSprintListingPage()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo(OpenTheirBrowserOn.ThePage(SprintList.ForOpenSprints()));
    }

    [When(@"Youssef opens the sprint listing page for closed sprints")]
    public void WhenYoussefOpensTheSprintListingPageForClosedSprints()
    {
      var youssef = cast.Get<Youssef>();
      stage.ShineTheSpotlightOn(youssef);
      When(youssef).AttemptsTo(OpenTheirBrowserOn.ThePage(SprintList.ForClosedSprints()));
    }

    [When(@"(?:he|she|they) views? the sprint titled '([^']+)'")]
    public void WhenTheyViewTheSprintTitled(string sprintTitle)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo(ViewTheSprintDetail.ForSprint(sprintTitle));
    }

    [When(@"(?:he|she|they) reads? the (open|closed) tickets in this sprint")]
    public void WhenTheyReadTheTicketsInThisSprint(string openOrClosed)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      var ticketTitles = When(theActor).AttemptsTo(ReadTheTicketTitlesFromTheCurrentSprint.WhichAre(openOrClosed));
      context.Set(ticketTitles, CurrentTicketTitlesKey);
    }

    [Then(@"(?:he|she|they) should see the following tickets, in any order:")]
    public void ThenTheyShouldSeeTheFollowingTicketsInAnyOrder(Table expectedTicketTitles)
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

    [Then(@"(?:he|she|they) should see the following sprints, in order")]
    public void ThenTheyShouldSeeTheSprintsInOrder(Table expectedSprintNamesTable)
    {
      var expectedSprintNames = expectedSprintNamesTable
        .Rows
        .Select(x => x.Values.Single())
        .ToArray();

      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheText.OfAll(SprintList.SprintNames))
                    .Should()
                    .ContainInOrder(expectedSprintNames, because: "The displayed sprints should match the expectation");
    }

    [Then(@"(?:he|she|they) should see the following sprints")]
    public void ThenTheyShouldSeeTheSprints(Table expectedSprintNamesTable)
    {
      var expectedSprintNames = expectedSprintNamesTable
        .Rows
        .Select(x => x.Values.Single())
        .ToArray();

      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheText.OfAll(SprintList.SprintNames))
                    .Should()
                    .Contain(expectedSprintNames, because: "The displayed sprints should match the expectation");
    }

    [Then(@"(?:he|she|they) should see that the sprint titled '([^']*)' starts on (\d{4}-\d{1,2}-\d{1,2})")]
    public void ThenTheyShouldVerifyTheSprintStartDate(string sprintTitle, string dateString)
    {
      var expected = DateTime.Parse(dateString);

      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheStartDateFromTheSprintList.ForTheSprintTitle(sprintTitle))
                    .Should()
                    .Be(expected, because: "the sprint start date should match");
    }

    [Then(@"(?:he|she|they) should see that the sprint titled '([^']*)' ends on (\d{4}-\d{1,2}-\d{1,2})")]
    public void ThenTheyShouldVerifyTheSprintEndDate(string sprintTitle, string dateString)
    {
      var expected = DateTime.Parse(dateString);

      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheEndDateFromTheSprintList.ForTheSprintTitle(sprintTitle))
                    .Should()
                    .Be(expected, because: "the sprint end date should match");
    }

    [Then(@"(?:he|she|they) should see that the sprint has the following details")]
    public void ThenYoussefShouldSeeThatTheSprintHasTheFollowingDetails(Table table)
    {
      var expectedDetails = table.CreateInstance<SprintDetails>();
    
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).Should(VerifyThatTheSprintDetailsMatch.TheExpectations(expectedDetails));
    }

    [Then(@"(?:he|she|they) should see that the sprint description contains the word ""([^""]+)"" in bold text")]
    public void ThenTheyShouldSeeThatTheSprintDescriptionIncludesABoldWord(string expectedBoldText)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).Should(AssertThatTheSprintDescriptionHasBoldText.WithTheText(expectedBoldText));
    }

    public SprintViewingSteps(ICast cast, IStage stage, ScenarioContext context)
    {
      if(context == null)
        throw new ArgumentNullException(nameof(context));
      if(cast == null)
        throw new ArgumentNullException(nameof(cast));
      if(stage == null)
        throw new ArgumentNullException(nameof(stage));

      this.context = context;
      this.cast = cast;
      this.stage = stage;
    }
  }
}
