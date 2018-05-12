using System;
using Agiil.BDD.Pages;
using Agiil.BDD.Personas;
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
  public class TicketEditingSteps
  {
    readonly IStage stage;

    [Given(@"(?:he|she|they) (?:has|have) set the ticket labels to read '([^']+)' and submitted")]
    public void GivenTheyHaveSetTheTicketLabelsAndSubmitted(string labelNames)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Given(theActor).WasAbleTo(ChangeTheTicket.LabelsTo(labelNames));
      Given(theActor).WasAbleTo<SubmitTheEditedTicket>();
    }

    [When(@"(?:he|she|they) changes? the ticket title to '([^']*)' and clicks? submit")]
    public void WhenTheyChangeTheTicketTitleAndSubmits(string ticketTitle)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo(ChangeTheTicket.TitleTo(ticketTitle));
      When(theActor).AttemptsTo<SubmitTheEditedTicket>();
    }

    [Then(@"(?:he|she|they) should see a ticket-editing error message")]
    public void ThenTheyShouldSeeATicketEditingErrorMessage()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).Should(Wait.Until(EditTicket.SubmissionFailedErrorMessage).IsVisible());

      Then(theActor).ShouldSee(TheText.Of(EditTicket.SubmissionFailedErrorMessage))
                   .Should()
                   .Be("The ticket has not been edited.", because: "The error message should be visible");
    }

    [When(@"(?:he|she|they) changes? the ticket description to '([^']*)' and clicks? submit")]
    public void WhenTheyChangeTheTicketDescriptionAndSubmits(string ticketDescription)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo(ChangeTheTicket.DescriptionTo(ticketDescription));
      When(theActor).AttemptsTo<SubmitTheEditedTicket>();
    }

    [When(@"(?:he|she|they) changes? the ticket sprint to '([^']+)' and clicks? submit")]
    public void WhenTheyChangeTheSprintAndSubmits(string sprintName)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo(ChangeTheTicket.SprintTo(sprintName));
      When(theActor).AttemptsTo<SubmitTheEditedTicket>();
    }

    [When(@"(?:he|she|they) changes? the ticket type to '([^']+)' and clicks? submit")]
    public void WhenTheyChangeTheTicketTypeAndSubmits(string newType)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo(ChangeTheTicket.TypeTo(newType));
      When(theActor).AttemptsTo<SubmitTheEditedTicket>();
    }

    [When(@"(?:he|she|they) changes? the ticket labels to read '([^']+)' and clicks? submit")]
    public void WhenTheyChangeTheLabelsAndSubmit(string labels)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo(ChangeTheTicket.LabelsTo(labels));
      When(theActor).AttemptsTo<SubmitTheEditedTicket>();
    }

    public TicketEditingSteps(IStage stage)
    {
      if(stage == null)
        throw new ArgumentNullException(nameof(stage));

      this.stage = stage;
    }
  }
}
