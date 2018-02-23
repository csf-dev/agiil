using System;
using static CSF.Screenplay.StepComposer;
using TechTalk.SpecFlow;
using Agiil.BDD.Tasks.Auth;
using CSF.Screenplay.Actors;

namespace Agiil.BDD.Bindings.Auth
{
  [Binding]
  public class LogoutSteps
  {
    readonly IStage stage;

    [When("(?:he|she|they) logs? out")]
    public void WhenTheyLogOut()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo<LogOutOfTheSite>();
    }

    public LogoutSteps(IStage stage)
    {
      if(stage == null)
        throw new ArgumentNullException(nameof(stage));

      this.stage = stage;
    }
  }
}
