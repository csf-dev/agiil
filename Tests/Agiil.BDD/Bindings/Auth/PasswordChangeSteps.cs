using System;
using Agiil.BDD.Pages;
using Agiil.BDD.Personas;
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

    [When("Youssef correctly changes his password to '([^']+)'")]
    public void WhenYoussefChangesHisPassword(string newPassword)
    {
      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(ChangeTheirPassword.From(Youssef.Password).To(newPassword));
    }

    [When("Youssef attempts to change his password to '([^']+)' using an incorrect current password")]
    public void WhenYoussefChangesHisPasswordWithTheWrongCurrentPassword(string newPassword)
    {
      var fixture = new Fixture();
      var incorrectPassword = fixture.Create<string>();

      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(ChangeTheirPassword.From(incorrectPassword).To(newPassword));
    }

    [Then("Youssef should see a password-change success message")]
    public void ThenYoussefShouldSeeASuccessMessage()
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(TheText.Of(ChangePasswordPage.PasswordChangeFeedbackMessage))
               .Should()
               .StartWith("Your password has been changed.", because: "The password change should be a success");
    }

    [Then("Youssef should see a password-change failure message")]
    public void ThenYoussefShouldSeeAFailureMessage()
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(TheText.Of(ChangePasswordPage.PasswordChangeFeedbackMessage))
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
