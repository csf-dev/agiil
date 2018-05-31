using System;
using System.Linq;
using Agiil.BDD.Pages;
using Agiil.BDD.Tasks.Tickets;
using CSF.Screenplay;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Selenium.Builders;
using FluentAssertions;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class ReadATicketSteps
  {
    readonly IStage stage;

    [Then(@"(?:he|she|they) opens? a ticket with the title '([^']+)'")]
    public void ThenTheyOpenATicketWithTheTitle(string title)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).Should(OpenTheTicket.Titled(title));
    }

    [Then("(?:he|she|they) should see that the ticket description reads '([^']*)'")]
    public void ThenTheyShouldSeeThatTheTicketDescriptionIs(string description)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheTicket.Description())
                   .Should()
                   .Be(description);
    }

    [Then("(?:he|she|they) should see that the ticket title reads '([^']*)'")]
    public void ThenTheyShouldSeeThatTheTicketTitleIs(string title)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheTicket.Title())
                    .Should()
                    .Be(title);
    }

    [Then("(?:he|she|they) should see that the ticket is part of the sprint '([^']+)'")]
    public void ThenTheyShouldSeeThatTheTicketIsAPartOfTheSprint(string sprint)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheTicket.SprintTitle())
                   .Should()
                   .Be(sprint);
    }

    [Then(@"(?:he|she|they) should see that the creator of the current ticket is '([^']+)'")]
    public void ThenTheyShouldSeeThatTheCreatorOfTheCurrentTicketIs(string username)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheText.OfAll(TicketDetail.TicketCreatorUsername))
                   .Should()
                   .ContainInOrder(username);
    }

    [Then(@"(?:he|she|they) should see that the ticket state is (.+)")]
    public void ThenTheyShouldSeeThatTheTicketStateIs(string expectedState)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheText.Of(TicketDetail.TicketState))
                   .Should()
                   .Be(expectedState, because: "the state should match");
    }

    [Then(@"(?:he|she|they) should see that the ticket type is '([^']+)'")]
    public void ThenTheyShouldSeeThatTheTicketTypeIsAsExpected(string type)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheText.Of(TicketDetail.TicketType))
                   .Should()
                   .Be(type, because: "the type should match");
    }

    [Then(@"(?:he|she|they) should see that the ticket has the labels")]
    public void ThenTheyShouldSeeThatTheTicketHasTheLabels(Table expectedLabelsTable)
    {
      var expectedLabelNames = expectedLabelsTable.ToListOfStrings();

      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheText.OfAll(TicketDetail.LabelNames))
                    .Should()
                    .Contain(expectedLabelNames);
    }

    public ReadATicketSteps(IStage stage)
    {
      if(stage == null)
        throw new ArgumentNullException(nameof(stage));

      this.stage = stage;
    }
  }
}
