using System;
using CSF.Screenplay;
using static CSF.Screenplay.StepComposer;
using TechTalk.SpecFlow;
using CSF.Screenplay.Web.Builders;
using Agiil.BDD.PageComponents;
using Agiil.BDD.Tasks.Auth;

namespace Agiil.BDD.Bindings.Auth
{
  [Binding]
  public class LogoutSteps
  {
    readonly IScreenplayScenario screenplay;

    [When("Youssef logs out")]
    public void WhenYoussefLogsOut()
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo<LogOutOfTheSite>();
    }

    public LogoutSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));
      
      this.screenplay = screenplay;
    }
  }
}
