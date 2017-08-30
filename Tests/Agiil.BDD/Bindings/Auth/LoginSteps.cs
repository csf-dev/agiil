using System;
using Agiil.BDD.Abilities;
using Agiil.BDD.Actions;
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

    [Given("([A-Za-z0-9_-]+) is logged into the site as a normal user")]
    public void GivenJoeIsLoggedIntoTheSiteAsANormalUser(string actorName)
    {
      var autofixture = new Fixture();
      var password = autofixture.Create<string>();

      var april = screenplay.GetApril();
      Given(april).WasAbleTo(AddAUserAccount.WithTheUsername(actorName).AndThePassword(password));

      var joe = screenplay.GetJoe(actorName);
      joe.IsAbleTo(LogInWithAUserAccount.WithTheUsername(actorName).AndThePassword(password));

      Given(joe).WasAbleTo<LogInWithTheirAccount>();
    }

    [When("([A-Za-z0-9_-]+) attempts to log in with a username '([A-Za-z0-9_-]+)' and password '([^']+)'")]
    public void WhenJoeAttemptsToLogin(string actorName, string username, string password)
    {
      var joe = screenplay.GetJoe(actorName);

      When(joe).AttemptsTo(LogIntoTheSite.As(username).WithThePassword(password));
    }

    [Then("([A-Za-z0-9_-]+) should see a login failure message")]
    public void ThenJoeShouldSeeALoginFailureMessage(string actorName)
    {
      var joe = screenplay.GetJoe(actorName);

      Then(joe).Should<VerifyThatThereIsALoginFailureMessage>();
    }

    [Then("([A-Za-z0-9_-]+) should not be logged in")]
    public void ThenJoeShouldNotBeLoggedIn(string actorName)
    {
      var joe = screenplay.GetJoe(actorName);

      Then(joe).Should<VerifyThatTheyAreNotLoggedIn>();
    }

    [Then("([A-Za-z0-9_-]+) should be logged in as ''([A-Za-z0-9_-]+)'")]
    public void ThenJoeShouldBeLoggedIn(string actorName, string username)
    {
      var joe = screenplay.GetJoe(actorName);

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
