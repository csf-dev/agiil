using System;
using Agiil.BDD.Models.Tickets;
using Agiil.BDD.Pages;
using Agiil.BDD.Personas;
using Agiil.BDD.Tasks.Tickets;
using CSF.Screenplay;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Selenium.Builders;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class TicketCreationSteps
  {
    readonly ICast cast;
    readonly IStage stage;

    [When("Youssef creates the following ticket using the create ticket page")]
    public void WhenYoussefCreatesATicket(Table detailsTable)
    {
      var details = detailsTable.CreateInstance<TicketCreationDetails>();

      var youssef = cast.Get<Youssef>();
      stage.ShineTheSpotlightOn(youssef);
      When(youssef).AttemptsTo(CreateANewTicket.WithTheDetails(details));
    }

    [Then("(?:he|she|they) should see a ticket created success message")]
    public void ThenTheyShouldSeeATicketCreatedSuccessMessage()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheText.Of(CreateNewTicket.CreationSuccessMessage))
                   .Should()
                   .StartWith("The ticket was created successfully", because: "The ticket creation was a success");
    }

    [Then("(?:he|she|they) should see a ticket creation failure message")]
    public void ThenTheyShouldSeeATicketCreationFailureMessage()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheText.Of(CreateNewTicket.CreationFailureMessage))
                   .Should()
                   .StartWith("The ticket was not created", because: "The ticket creation failed");
    }

    public TicketCreationSteps(ICast cast, IStage stage)
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
