using System;
using Agiil.BDD.Tasks.Tickets;
using CSF.Screenplay;
using CSF.Screenplay.Actors;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class OpenCloseTicketSteps
  {
    readonly IStage stage;

    [Given(@"(?:he|she|they) (?:has|have) closed the ticket")]
    public void GivenTheyHaveClosedTheTicket()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Given(theActor).WasAbleTo(ChangeTheTicket.StatusToClosed());
    }

    [When(@"(?:he|she|they) closes? the ticket")]
    public void WhenTheyCloseTheTicket()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo(ChangeTheTicket.StatusToClosed());
    }

    [When(@"(?:he|she|they) reopens? the ticket")]
    public void WhenTheyReopenTheTicket()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo(ChangeTheTicket.StatusToReopened());
    }

    public OpenCloseTicketSteps(IStage stage)
    {
      if(stage == null)
        throw new ArgumentNullException(nameof(stage));

      this.stage = stage;
    }
  }
}
