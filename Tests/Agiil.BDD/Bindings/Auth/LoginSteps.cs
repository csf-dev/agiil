using System;
using Agiil.BDD.Personas;
using Agiil.BDD.Tasks.Auth;
using CSF.Screenplay.Actors;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Auth
{
  [Binding]
  public class LoginSteps
  {
    readonly ICast cast;
    readonly IStage stage;

    [When("Joe attempts to log in with a username '([A-Za-z0-9_-]+)' and password '([^']+)'")]
    public void WhenJoeAttemptsToLogin(string username, string password)
    {
      var joe = cast.Get<Joe>();
      stage.ShineTheSpotlightOn(joe);

      When(joe).AttemptsTo(LogIntoTheSite.As(username).WithThePassword(password));
    }

    [When("Youssef attempts to log in with a username '([A-Za-z0-9_-]+)' and password '([^']+)'")]
    public void WhenYoussefAttemptsToLogin(string username, string password)
    {
      var youssef = cast.Get<Youssef>();
      stage.ShineTheSpotlightOn(youssef);

      When(youssef).AttemptsTo(LogIntoTheSite.As(username).WithThePassword(password));
    }

    [When("(?:he|she|they) attempts? to log in with a username '([A-Za-z0-9_-]+)' and password '([^']+)'")]
    public void WhenTheyAttemptToLogin(string username, string password)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo(LogIntoTheSite.As(username).WithThePassword(password));
    }

    [Then("(?:he|she|they) should see a login failure message")]
    public void ThenTheyShouldSeeALoginFailureMessage()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).Should<VerifyThatThereIsALoginFailureMessage>();
    }

    [Then("(?:he|she|they) should not be logged in")]
    public void ThenTheyShouldNotBeLoggedIn()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).Should<VerifyThatTheyAreNotLoggedIn>();
    }

    [Then("(?:he|she|they) should be logged in as '([A-Za-z0-9_-]+)'")]
    public void ThenTheyShouldBeLoggedIn(string username)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).Should(VerifyThatTheyAreLoggedIn.As(username));
    }

    public LoginSteps(ICast cast, IStage stage)
    {
      if(cast == null)
        throw new ArgumentNullException(nameof(cast));
      if(stage == null)
        throw new ArgumentNullException(nameof(stage));

      this.cast = cast;
      this.stage = stage;
    }
  }
}
