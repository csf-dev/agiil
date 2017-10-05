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
  public class FindATicketSteps
  {
    readonly IScreenplayScenario screenplay;

    [When("Youssef looks at the list of tickets")]
    public void WhenYoussefLooksAtTheListOfTickets()
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(OpenTheirBrowserOn.ThePage<TicketList>());
    }

    [Then("Youssef looks at the list of tickets")]
    public void ThenYoussefLooksAtTheListOfTickets()
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).Should(OpenTheirBrowserOn.ThePage<TicketList>());
    }

    [Then("Youssef should be able to find a ticket with the title '([^']+)'")]
    public void ThenYoussefShouldBeAbleToFindATicketByTitle(string title)
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).Should(VerifyThatThereIsATicket.WithTheTitle(title));
    }

    [Then("Youssef should not be able to find a ticket with the title '([^']+)'")]
    public void ThenYoussefShouldNotBeAbleToFindATicketByTitle(string title)
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).Should(VerifyThatThereIsNotATicket.WithTheTitle(title));
    }

    public FindATicketSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));

      this.screenplay = screenplay;
    }
  }
}
