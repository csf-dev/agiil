using System;
using Agiil.BDD.Personas;
using Agiil.BDD.Tasks.App;
using CSF.Screenplay.Actors;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.App
{
  [Binding]
  public class ProjectSetupSteps
  {
    readonly ICast cast;
    readonly Lazy<ITestRunner> testRunner;

    [Given("April has set up the simple sample project")]
    public void AprilHasSetUpTheSimpleSampleProject()
    {
      testRunner.Value.Given("April can act as the application");

      var april = cast.Get<April>();

      Given(april).WasAbleTo<SetupTheSimpleSampleProject>();
    }

    public ProjectSetupSteps(ICast cast, Lazy<ITestRunner> testRunner)
    {
      if(testRunner == null)
        throw new ArgumentNullException(nameof(testRunner));
      if(cast == null)
        throw new ArgumentNullException(nameof(cast));

      this.cast = cast;
      this.testRunner = testRunner;
    }
  }
}
