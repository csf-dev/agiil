using System;
using Agiil.BDD.Actions;
using Agiil.BDD.Bindings.Actors;
using Agiil.BDD.Personas;
using CSF.Screenplay;
using CSF.Screenplay.Actors;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.App
{
  [Binding]
  public class InstallationSteps
  {
    readonly ICast cast;
    readonly Lazy<ITestRunner> testRunner;
    readonly Lazy<AprilSteps> aprilSteps;

    [Given("Agiil has just been installed")]
    public void GivenAgiilHasJustBeenInstalled()
    {
      // Currently bugged due to https://github.com/csf-dev/CSF.Screenplay/issues/126
      // testRunner.Value.Given("April can act as the application");
      aprilSteps.Value.GivenAprilCanActAsTheApplication();

      var april = cast.Get<April>();

      Given(april).WasAbleTo<InstallTheApplication>();
    }

    public InstallationSteps(ICast cast, Lazy<ITestRunner> testRunner, Lazy<AprilSteps> aprilSteps)
    {
      if(aprilSteps == null)
        throw new ArgumentNullException(nameof(aprilSteps));
      if(testRunner == null)
        throw new ArgumentNullException(nameof(testRunner));
      if(cast == null)
        throw new ArgumentNullException(nameof(cast));
      
      this.aprilSteps = aprilSteps;
      this.cast = cast;
      this.testRunner = testRunner;
    }
  }
}
