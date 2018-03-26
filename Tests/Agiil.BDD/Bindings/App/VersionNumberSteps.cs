using System;
using Agiil.BDD.Personas;
using Agiil.BDD.Tasks.App;
using CSF.Screenplay;
using static CSF.Screenplay.StepComposer;
using CSF.Screenplay.Selenium.Builders;
using TechTalk.SpecFlow;
using Agiil.BDD.Pages;
using FluentAssertions;

namespace Agiil.BDD.Bindings.App
{
  [Binding]
  public class VersionNumberSteps
  {
    const string VersionNumberContextKey = "Application version number";

    readonly ScenarioContext context;
    readonly ICast cast;
    readonly IStage stage;

    [Given("April overrides the application version number to '([^']+)'")]
    public void AprilOverridesTheApplicationVersionNumber(string versionNumber)
    {
      var april = cast.Get<April>();
      stage.ShineTheSpotlightOn(april);
      Given(april).WasAbleTo(OverrideTheApplicationVersion.To(versionNumber));
    }

    [Given("(he|she|they) overrides? the application version number to '([^']+)'")]
    public void TheyOverrideTheApplicationVersionNumber(string versionNumber)
    {
      var actor = stage.GetTheActorInTheSpotlight();
      Given(actor).WasAbleTo(OverrideTheApplicationVersion.To(versionNumber));
    }

    [When(@"Youssef reads the version number from the application footer")]
    public void WhenYoussefReadsTheVersionNumberFromTheFooter()
    {
      var youssef = cast.Get<Youssef>();
      stage.ShineTheSpotlightOn(youssef);

      When(youssef).AttemptsTo(OpenTheirBrowserOn.ThePage<HomePage>());
      When(youssef).AttemptsTo(Wait.UntilThePageLoads());
      var version = When(youssef).Reads(TheText.Of(AnyPage.FooterApplicationVersion));
      context.Set(version, VersionNumberContextKey);
    }

    [Then(@"he should see that the version number is '([^']+)'")]
    public void ThenHeShouldSeeThatTheVersionNumberIs(string expected)
    {
      var version = context.Get<string>(VersionNumberContextKey);
      version.Should().Be(expected);
    }

    [Then("April should clear the application version number override")]
    public void AprilClearsTheApplicationVersionNumberOverride()
    {
      var april = cast.Get<April>();
      stage.ShineTheSpotlightOn(april);
      Then(april).Should(OverrideTheApplicationVersion.To(null));
    }

    [Then("(he|she|they) should clear the application version number override")]
    public void TheyClearTheApplicationVersionNumberOverride()
    {
      var actor = stage.GetTheActorInTheSpotlight();
      Then(actor).Should(OverrideTheApplicationVersion.To(null));
    }

    public VersionNumberSteps(ICast cast, IStage stage, ScenarioContext context)
    {
      if(context == null)
        throw new ArgumentNullException(nameof(context));
      if(stage == null)
        throw new ArgumentNullException(nameof(stage));
      if(cast == null)
        throw new ArgumentNullException(nameof(cast));

      this.context = context;
      this.stage = stage;
      this.cast = cast;
    }
  }
}
