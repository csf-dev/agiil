using System;
using Agiil.BDD.Pages;
using Agiil.BDD.Tasks.Tickets;
using CSF.Screenplay;
using CSF.Screenplay.Web.Builders;
using FluentAssertions;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class TicketEditingSteps
  {
    readonly IScreenplayScenario screenplay;

    [Given(@"Youssef has opened a ticket with the title '([^']+)' for editing")]
    public void GivenYoussefHasOpenedATicketForEditingByTitle(string ticketTitle)
    {
      var youssef = screenplay.GetYoussef();
      Given(youssef).WasAbleTo(OpenTheTicket.ForEditingByTitle(ticketTitle));
    }

    [When(@"Youssef changes the ticket title to '([^']*)' and clicks submit")]
    public void WhenYoussefChangesTheTicketTitleAndSubmits(string ticketTitle)
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(ChangeTheTicket.TitleTo(ticketTitle));
      When(youssef).AttemptsTo<SubmitTheEditedTicket>();
    }

    [Then(@"Youssef should see a ticket-editing error message")]
    public void ThenYoussefShouldSeeATicketEditingErrorMessage()
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).Should(Wait.Until(EditTicket.SubmissionFailedErrorMessage).IsVisible());

      Then(youssef).ShouldSee(TheText.Of(EditTicket.SubmissionFailedErrorMessage))
                   .Should()
                   .Be("The ticket has not been edited.", because: "The error message should be visible");
    }

    [When(@"Youssef changes the ticket description to '([^']*)' and clicks submit")]
    public void WhenYoussefChangesTheTicketDescriptionAndSubmits(string ticketDescription)
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(ChangeTheTicket.DescriptionTo(ticketDescription));
      When(youssef).AttemptsTo<SubmitTheEditedTicket>();
    }

    [When(@"Youssef changes the ticket sprint to '([^']+)' and clicks submit")]
    public void WhenYoussefChangesTheSprintAndSubmits(string sprintName)
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(ChangeTheTicket.SprintTo(sprintName));
      When(youssef).AttemptsTo<SubmitTheEditedTicket>();
    }

    [When(@"Youssef changes the ticket type to '([^']+)' and clicks submit")]
    public void WhenYoussefChangesTheTicketTypeAndSubmits(string newType)
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(ChangeTheTicket.TypeTo(newType));
      When(youssef).AttemptsTo<SubmitTheEditedTicket>();
    }

    public TicketEditingSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));

      this.screenplay = screenplay;
    }
  }
}
