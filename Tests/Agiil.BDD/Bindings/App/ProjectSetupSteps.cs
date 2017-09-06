using System;
using Agiil.BDD.Actions;
using Agiil.BDD.Tasks.App;
using CSF.Screenplay;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.App
{
  [Binding]
  public class ProjectSetupSteps
  {
    readonly IScreenplayScenario screenplay;

    [Given("April has set up the simple sample project")]
    public void AprilHasSetUpTheSimpleSampleProject()
    {
      var april = screenplay.GetApril();

      Given(april).WasAbleTo<InstallTheApplication>();
      Given(april).WasAbleTo<SetupTheSimpleSampleProject>();
    }

    public ProjectSetupSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));

      this.screenplay = screenplay;
    }
  }
}
