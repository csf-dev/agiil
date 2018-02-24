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
  public class FindATicketSteps
  {
    readonly ICast cast;
    readonly IStage stage;

    [When("Youssef looks at the list of tickets")]
    public void WhenYoussefLooksAtTheListOfTickets()
    {
      var youssef = cast.Get<Youssef>();
      stage.ShineTheSpotlightOn(youssef);
      When(youssef).AttemptsTo(OpenTheirBrowserOn.ThePage<TicketList>());
    }

    [When("(?:he|she|they) looks? at the list of tickets")]
    public void WhenTheyLookAtTheListOfTickets()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo(OpenTheirBrowserOn.ThePage<TicketList>());
    }

    [Then("(?:he|she|they) looks at the list of tickets")]
    public void ThenTheyLookAtTheListOfTickets()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).Should(OpenTheirBrowserOn.ThePage<TicketList>());
    }

    [Then("(?:he|she|they) should be able to find a ticket with the title '([^']+)'")]
    public void ThenTheyShouldBeAbleToFindATicketByTitle(string title)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).Should(VerifyThatThereIsATicket.WithTheTitle(title));
    }

    [Then("(?:he|she|they) should not be able to find a ticket with the title '([^']+)'")]
    public void ThenTheyShouldNotBeAbleToFindATicketByTitle(string title)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).Should(VerifyThatThereIsNotATicket.WithTheTitle(title));
    }

    public FindATicketSteps(ICast cast, IStage stage)
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
