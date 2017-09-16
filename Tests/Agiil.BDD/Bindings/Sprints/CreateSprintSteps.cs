using System;
using Agiil.BDD.Models.Sprints;
using Agiil.BDD.Pages;
using Agiil.BDD.Tasks.Sprints;
using CSF.Screenplay;
using CSF.Screenplay.Web.Builders;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.Sprints
{
  [Binding]
  public class CreateSprintSteps
  {
    readonly IScreenplayScenario screenplay;

    [Given(@"Youssef has opened the new sprint page")]
    public void GivenYoussefHasOpenedTheNewSprintPage()
    {
      var youssef = screenplay.GetYoussef();
      Given(youssef).WasAbleTo(OpenTheirBrowserOn.ThePage<CreateSprint>());
    }

    [When(@"Youssef enters the following sprint details and presses submit")]
    public void WhenYoussefEntersTheFollowingSprintDetailsAndPressesSubmit(Table table)
    {
      var details = table.CreateInstance<SprintCreationDetails>();

      var youssef = screenplay.GetYoussef();
      When(youssef).AttemptsTo(CreateASprint.WithTheDetails(details));
    }

    public CreateSprintSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));
      this.screenplay = screenplay;
    }
  }
}
