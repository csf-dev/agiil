using System;
using Agiil.BDD.Abilities;
using Agiil.BDD.Actions;
using CSF.Screenplay;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Auth
{
  [Binding]
  public class UserAccountSteps
  {
    readonly IScreenplayScenario screenplay;

    [Given(@"([A-Za-z0-9_-]+) has a user account with the username '([A-Za-z0-9_-]+)' and password '([^']+)'")]
    public void GivenJoeHasAUserAccount(string actorName, string username, string password)
    {
      var april = screenplay.GetApril();
      Given(april).WasAbleTo(AddAUserAccount.WithTheUsername(username).AndThePassword(password));

      var joe = screenplay.GetJoe(actorName);
      joe.IsAbleTo(LogInWithAUserAccount.WithTheUsername(username).AndThePassword(password));
    }

    public UserAccountSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));
      this.screenplay = screenplay;
    }
  }
}
