using System;
using static CSF.Screenplay.StepComposer;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Agiil.BDD.Tasks.Sprints;
using Agiil.BDD.Pages;
using FluentAssertions;
using Agiil.BDD.Models.Sprints;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Selenium.Builders;

namespace Agiil.BDD.Bindings.Sprints
{
  [Binding]
  public class SprintEditingSteps
  {
    readonly ICast cast;
    readonly IStage stage;

    [Given(@"(?:he|she|they) begins? editing the sprint titled '([^']+)'")]
    public void GivenTheyBeginEditingTheSprintTitled(string title)
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Given(theActor).WasAbleTo(BeginEditingTheSprint.Titled(title));
    }

    [When(@"(?:he|she|they) enters? the following sprint details and clicks submit")]
    public void WhenTheyEnterTheFollowingSprintDetailsAndClicksSubmit(Table table)
    {
      var spec = table.CreateInstance<SprintDetails>();

      var theActor = stage.GetTheActorInTheSpotlight();
      When(theActor).AttemptsTo(EditTheSprint.UsingTheSpecification(spec));
    }

    [Then(@"(?:he|she|they) should see a sprint-editing failure message")]
    public void ThenTheyShouldSeeASprint_EditingFailureMessage()
    {
      var theActor = stage.GetTheActorInTheSpotlight();
      Then(theActor).ShouldSee(TheVisibility.Of(EditSprint.EditFailureMessage))
                    .Should()
                    .BeTrue("the message should be visible");
    }

    public SprintEditingSteps(ICast cast, IStage stage)
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
