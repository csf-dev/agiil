using System;
using Agiil.BDD.Models.Sprints;
using Agiil.BDD.Pages;
using Agiil.BDD.Personas;
using Agiil.BDD.Tasks.Sprints;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Selenium.Builders;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Sprints
{
  [Binding]
  public class CreateSprintSteps
  {
    readonly ICast cast;
    readonly IStage stage;

    [Given(@"Youssef has opened the new sprint page")]
    public void GivenYoussefHasOpenedTheNewSprintPage()
    {
      var youssef = cast.Get<Youssef>();
      stage.ShineTheSpotlightOn(youssef);
      Given(youssef).WasAbleTo(OpenTheirBrowserOn.ThePage<CreateSprint>());
    }

    [When(@"(?:he|she|they) enters? the following sprint details and presses submit")]
    public void WhenTheyEnterTheFollowingSprintDetailsAndPressesSubmit(Table table)
    {
      var details = table.CreateInstance<SprintDetails>();

      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo(CreateASprint.WithTheDetails(details));
    }

    [Then(@"(?:he|she|they) should see a create-sprint failure message")]
    public void ThenTheyShouldSeeACreateSprintFailureMessage()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheVisibility.Of(CreateSprint.FailureMessage))
                    .Should()
                    .BeTrue(because: "the sprint should not have been created");
    }

    public CreateSprintSteps(ICast cast, IStage stage)
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
