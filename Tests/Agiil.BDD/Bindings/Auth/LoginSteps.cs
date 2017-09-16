using System;
using Agiil.BDD.Abilities;
using Agiil.BDD.Actions;
using Agiil.BDD.Personas;
using Agiil.BDD.Tasks.Auth;
using CSF.Screenplay;
using Ploeh.AutoFixture;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Auth
{
  [Binding]
  public class LoginSteps
  {
    readonly IScreenplayScenario screenplay;

    [Given("Youssef is logged into the site as a normal user")]
    public void GivenYoussefIsLoggedIntoTheSiteAsANormalUser()
    {
      var april = screenplay.GetApril();
      var youssef = screenplay.GetYoussef();

      Given(april).WasAbleTo(AddAUserAccount.WithTheUsername(Youssef.Name).AndThePassword(Youssef.Password));
      Given(youssef).WasAbleTo<LogInWithTheirAccount>();
    }

    [When("Joe attempts to log in with a username '([A-Za-z0-9_-]+)' and password '([^']+)'")]
    public void WhenJoeAttemptsToLogin(string username, string password)
    {
      var joe = screenplay.GetJoe();
      When(joe).AttemptsTo(LogIntoTheSite.As(username).WithThePassword(password));
    }

    [When("Youssef attempts to log in with a username '([A-Za-z0-9_-]+)' and password '([^']+)'")]
    public void WhenYoussefAttemptsToLogin(string username, string password)
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(LogIntoTheSite.As(username).WithThePassword(password));
    }

    [Then("Joe should see a login failure message")]
    public void ThenJoeShouldSeeALoginFailureMessage()
    {
      var joe = screenplay.GetJoe();
      Then(joe).Should<VerifyThatThereIsALoginFailureMessage>();
    }

    [Then("Joe should not be logged in")]
    public void ThenJoeShouldNotBeLoggedIn()
    {
      var joe = screenplay.GetJoe();
      Then(joe).Should<VerifyThatTheyAreNotLoggedIn>();
    }

    [Then("Joe should be logged in as '([A-Za-z0-9_-]+)'")]
    public void ThenJoeShouldBeLoggedIn(string username)
    {
      var joe = screenplay.GetJoe();
      Then(joe).Should(VerifyThatTheyAreLoggedIn.As(username));
    }

    public LoginSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));
      
      this.screenplay = screenplay;
    }
  }
}
