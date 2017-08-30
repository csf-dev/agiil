using System;
using Agiil.BDD.Pages;
using Agiil.BDD.Tasks.Auth;
using CSF.Screenplay;
using CSF.Screenplay.Web.Builders;
using FluentAssertions;
using Ploeh.AutoFixture;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Auth
{
  [Binding]
  public class PasswordChangeSteps
  {
    readonly IScreenplayScenario screenplay;

    [When("([A-Za-z0-9_-]+) correctly changes (?:his|her) password to '([^']+)'")]
    public void WhenJoeChangesHisPassword(string actorName, string newPassword)
    {
      var joe = screenplay.GetJoe(actorName);
      When(joe).AttemptsTo(ChangeTheirPassword.FromTheirOldPasswordTo(newPassword));
    }

    [When("([A-Za-z0-9_-]+) attempts to change (?:his|her) password to '([^']+)' using an incorrect current password")]
    public void WhenJoeChangesHisPasswordWithTheWrongCurrentPassword(string actorName, string newPassword)
    {
      var fixture = new Fixture();
      var incorrectPassword = fixture.Create<string>();

      var joe = screenplay.GetJoe(actorName);
      When(joe).AttemptsTo(ChangeTheirPassword.From(incorrectPassword).To(newPassword));
    }

    [Then("([A-Za-z0-9_-]+) should see a password-change success message")]
    public void ThenJoeShouldSeeASuccessMessage(string actorName)
    {
      var joe = screenplay.GetJoe(actorName);
      Then(joe).ShouldSee(TheText.Of(ChangePasswordPage.PasswordChangeFeedbackMessage))
               .Should()
               .StartWith("Your password has been changed.", because: "The password change should be a success");
    }

    [Then("([A-Za-z0-9_-]+) should see a password-change failure message")]
    public void ThenJoeShouldSeeAFailureMessage(string actorName)
    {
      var joe = screenplay.GetJoe(actorName);
      Then(joe).ShouldSee(TheText.Of(ChangePasswordPage.PasswordChangeFeedbackMessage))
               .Should()
               .StartWith("Your password was not changed.", because: "The password change should have failed");
    }

    public PasswordChangeSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));
      this.screenplay = screenplay;
    }
  }
}
