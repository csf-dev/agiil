using System;
using Agiil.BDD.Abilities;
using Agiil.BDD.Actions;
using Agiil.BDD.Personas;
using CSF.Screenplay;
using CSF.Screenplay.Actors;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Auth
{
  [Binding]
  public class UserAccountSteps
  {
    readonly ICast cast;
    readonly Lazy<ITestRunner> testRunner;

    [Given(@"April adds a user account with the username '([A-Za-z0-9_-]+)' and password '([^']+)'")]
    public void GivenAprilAddsAUserAccount(string username, string password)
    {
      testRunner.Value.Given("April can act as the application");

      var april = cast.Get<April>();

      Given(april).WasAbleTo(AddAUserAccount.WithTheUsername(username).AndThePassword(password));
    }

    [Given(@"Joe has a user account with the username '([A-Za-z0-9_-]+)' and password '([^']+)'")]
    public void GivenJoeHasAUserAccount(string username, string password)
    {
      testRunner.Value.Given($"April adds a user account with the username '{username}' and password '{password}'");

      var joe = cast.Get<Joe>();
      joe.IsAbleTo(LogInWithAUserAccount.WithTheUsername(username).AndThePassword(password));
    }

    [Given(@"Youssef has a user account")]
    public void GivenYoussefHasAUserAccount()
    {
      testRunner.Value.Given($"April adds a user account with the username '{Youssef.Username}' and password '{Youssef.Password}'");
      testRunner.Value.Given("Youssef can log in with his username and password");
    }


    public UserAccountSteps(ICast cast, Lazy<ITestRunner> testRunner)
    {
      if(testRunner == null)
        throw new ArgumentNullException(nameof(testRunner));
      if(cast == null)
        throw new ArgumentNullException(nameof(cast));

      this.cast = cast;
      this.testRunner = testRunner;
    }
  }
}
