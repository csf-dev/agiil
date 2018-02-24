using System;
using Agiil.BDD.Pages;
using Agiil.BDD.Personas;
using Agiil.BDD.Tasks.Tickets;
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
    readonly ICast cast;
    readonly IStage stage;

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

    public TicketEditingSteps(ICast cast, IStage stage)
    {
      if(stage == null)
        throw new ArgumentNullException(nameof(stage));
      if(cast == null)
        throw new ArgumentNullException(nameof(cast));

      this.cast = cast;
      this.stage = stage;
    }
  }
}
