using System;
using CSF.Screenplay;
using static CSF.Screenplay.StepComposer;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Agiil.BDD.Tasks.Sprints;
using CSF.Screenplay.Web.Builders;
using Agiil.BDD.Pages;
using FluentAssertions;
using Agiil.BDD.Models.Sprints;

namespace Agiil.BDD.Bindings.Sprints
{
  [Binding]
  public class SprintEditingSteps
  {
    readonly IScreenplayScenario screenplay;

    [Given(@"Youssef begins editing the sprint titled '([^']+)'")]
    public void GivenYoussefBeginsEditingTheSprintTitled(string title)
    {
      var youssef = screenplay.GetYoussef();
      Given(youssef).WasAbleTo(BeginEditingTheSprint.Titled(title));
    }

    [When(@"Youssef enters the following sprint details and clicks submit")]
    public void WhenYoussefEntersTheFollowingSprintDetailsAndClicksSubmit(Table table)
    {
      var spec = table.CreateInstance<SprintDetails>();

      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(EditTheSprint.UsingTheSpecification(spec));
    }

    [Then(@"Youssef should see a sprint-editing failure message")]
    public void ThenYoussefShouldSeeASprint_EditingFailureMessage()
    {
      var youssef = screenplay.GetYoussef();
      Then(youssef).ShouldSee(TheVisibility.Of(EditSprint.EditFailureMessage))
                   .Should()
                   .BeTrue("the message should be visible");
    }

    public SprintEditingSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));
      this.screenplay = screenplay;
    }
  }
}
