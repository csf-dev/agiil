using System;
using Agiil.BDD.Pages;
using Agiil.BDD.Personas;
using Agiil.BDD.Tasks.Auth;
using CSF.Screenplay;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Selenium.Builders;
using FluentAssertions;
using Ploeh.AutoFixture;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Auth
{
  [Binding]
  public class PasswordChangeSteps
  {
    readonly ICast cast;
    readonly IStage stage;

    [When("Youssef correctly changes his password to '([^']+)'")]
    public void WhenYoussefChangesHisPassword(string newPassword)
    {
      var youssef = cast.Get<Youssef>();
      stage.ShineTheSpotlightOn(youssef);
      When(youssef).AttemptsTo(ChangeTheirPassword.From(Youssef.Password).To(newPassword));
    }

    [When("Youssef attempts to change his password to '([^']+)' using an incorrect current password")]
    public void WhenYoussefChangesHisPasswordWithTheWrongCurrentPassword(string newPassword)
    {
      var fixture = new Fixture();
      var incorrectPassword = fixture.Create<string>();

      var youssef = cast.Get<Youssef>();
      stage.ShineTheSpotlightOn(youssef);
      When(youssef).AttemptsTo(ChangeTheirPassword.From(incorrectPassword).To(newPassword));
    }

    [Then("(?:he|she|they) should see a password-change success message")]
    public void ThenTheyShouldSeeASuccessMessage()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheText.Of(ChangePassword.PasswordChangeFeedbackMessage))
               .Should()
               .StartWith("Your password has been changed.", because: "The password change should be a success");
    }

    [Then("(?:he|she|they) should see a password-change failure message")]
    public void ThenTheyShouldSeeAFailureMessage()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheText.Of(ChangePassword.PasswordChangeFeedbackMessage))
               .Should()
               .StartWith("Your password was not changed.", because: "The password change should have failed");
    }

    public PasswordChangeSteps(ICast cast, IStage stage)
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
