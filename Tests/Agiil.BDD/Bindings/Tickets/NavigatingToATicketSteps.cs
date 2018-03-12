using System;
using Agiil.BDD.Personas;
using Agiil.BDD.Tasks.Tickets;
using CSF.Screenplay;
using CSF.Screenplay.Actors;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class NavigatingToATicketSteps
  {
    readonly ICast cast;
    readonly IStage stage;

    [Given("Youssef has navigated to the ticket with the title '([^']+)'")]
    public void GivenYoussefHasNavigatedToTheTicketWithTheTitle(string title)
    {
      var youssef = cast.Get<Youssef>();
      stage.ShineTheSpotlightOn(youssef);
      Given(youssef).WasAbleTo(OpenTheTicket.Titled(title));
    }

    [Given(@"Youssef has navigated to the ticket with the title '([^']+)' and opened it for editing")]
    public void GivenYoussefHasNavigatedToTheTicketWithTheTitleAndOpenedItForEditing(string ticketTitle)
    {
      var youssef = cast.Get<Youssef>();
      stage.ShineTheSpotlightOn(youssef);
      Given(youssef).WasAbleTo(OpenTheTicket.ForEditingByTitle(ticketTitle));
    }

    [When("Youssef navigates to the ticket with the title '([^']+)'")]
    public void WhenYoussefNavigatesToTheTicketWithTheTitle(string title)
    {
      var youssef = cast.Get<Youssef>();
      stage.ShineTheSpotlightOn(youssef);
      When(youssef).AttemptsTo(OpenTheTicket.Titled(title));
    }

    [When("(?:he|she|they) navigates? to the ticket with the title '([^']+)'")]
    public void WhenTheyNavigateToTheTicketWithTheTitle(string title)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo(OpenTheTicket.Titled(title));
    }

    [Then("(?:he|she|they) navigates? to the ticket with the title '([^']+)'")]
    public void ThenTheyNavigateToTheTicketWithTheTitle(string title)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).Should(OpenTheTicket.Titled(title));
    }

    public NavigatingToATicketSteps(ICast cast, IStage stage)
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
