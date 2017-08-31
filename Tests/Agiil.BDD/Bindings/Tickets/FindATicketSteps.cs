using System;
using Agiil.BDD.Tasks.Tickets;
using CSF.Screenplay;
using FluentAssertions;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class FindATicketSteps
  {
    readonly IScreenplayScenario screenplay;

    [Then("Youssef should be able to find a ticket with the title '([^']+)'")]
    public void ThenYoussefShouldBeAbleToFindATicketByTitle(string title)
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(ThereIsATicket.WithTheTitle(title))
                   .Should()
                   .BeTrue(because: "The ticket should exist");
    }

    public FindATicketSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));

      this.screenplay = screenplay;
    }
  }
}
