using System;
using Agiil.BDD.Tasks.Tickets;
using CSF.Screenplay;
using FluentAssertions;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class ReadATicketSteps
  {
    readonly IScreenplayScenario screenplay;

    [When("Youssef opens a ticket with the title '([^']+)'")]
    public void WhenYoussefOpensATitleWithTheTitle(string title)
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(OpenTheTicket.Titled(title));
    }

    [Then("Youssef should see that the ticket description reads '([^']+)'")]
    public void ThenYoussefShouldSeeThatTheTicketDescriptionIs(string description)
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(ThatTheTicket.Description())
                   .Should()
                   .Be(description);
    }

    [Then("Youssef should see that the ticket is part of '([^']+)'")]
    public void ThenYoussefShouldSeeThatTheTicketIsAPartOf(string sprint)
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(ThatTheTicket.SprintTitle())
                   .Should()
                   .Be(sprint);
    }

    public ReadATicketSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));

      this.screenplay = screenplay;
    }
  }
}
