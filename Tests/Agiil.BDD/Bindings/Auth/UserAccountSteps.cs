using System;
using Agiil.BDD.Abilities;
using Agiil.BDD.Actions;
using Agiil.BDD.Bindings.Actors;
using Agiil.BDD.Personas;
using CSF.FlexDi;
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
    readonly IResolvesServices resolver;

    [Given(@"April adds a user account with the username '([A-Za-z0-9_-]+)' and password '([^']+)'")]
    public void GivenAprilAddsAUserAccount(string username, string password)
    {
      // Currently bugged due to https://github.com/csf-dev/CSF.Screenplay/issues/126
      //testRunner.Value.Given("April can act as the application");
      resolver.Resolve<AprilSteps>().GivenAprilCanActAsTheApplication();

      var april = cast.Get<April>();

      Given(april).WasAbleTo(AddAUserAccount.WithTheUsername(username).AndThePassword(password));
    }

    [Given(@"Joe has a user account with the username '([A-Za-z0-9_-]+)' and password '([^']+)'")]
    public void GivenJoeHasAUserAccount(string username, string password)
    {
      // Currently bugged due to https://github.com/csf-dev/CSF.Screenplay/issues/126
      //testRunner.Value.Given($"April adds a user account with the username '{username}' and password '{password}'");
      GivenAprilAddsAUserAccount(username, password);

      var joe = cast.Get<Joe>();
      joe.IsAbleTo(LogInWithAUserAccount.WithTheUsername(username).AndThePassword(password));
    }

    [Given(@"Youssef has a user account")]
    public void GivenYoussefHasAUserAccount()
    {
      // Currently bugged due to https://github.com/csf-dev/CSF.Screenplay/issues/126
      //testRunner.Value.Given($"April adds a user account with the username '{Youssef.Username}' and password '{Youssef.Password}'");
      //testRunner.Value.Given("Youssef can log in with his username and password");
      GivenAprilAddsAUserAccount(Youssef.Username, Youssef.Password);
      resolver.Resolve<YoussefSteps>().GivenYoussefCanLogInWithAUsernameAndPassword();
    }

    public UserAccountSteps(ICast cast, IResolvesServices resolver)
    {
      this.cast = cast ?? throw new ArgumentNullException(nameof(cast));
      this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
    }
  }
}
