using System;
using Agiil.BDD.Tasks.Tickets;
using CSF.Screenplay;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Tickets
{
  [Binding]
  public class OpenCloseTicketSteps
  {
    readonly IScreenplayScenario screenplay;

    [When(@"Youssef closes the ticket")]
    public void WhenYoussefClosesTheTicket()
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(ChangeTheTicket.StatusToClosed());
    }

    [When(@"Youssef reopens the ticket")]
    public void WhenYoussefReopensTheTicket()
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(ChangeTheTicket.StatusToReopened());
    }

    public OpenCloseTicketSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));
      this.screenplay = screenplay;
    }
  }
}
