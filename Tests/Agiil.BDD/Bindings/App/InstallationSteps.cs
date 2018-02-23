using System;
using Agiil.BDD.Actions;
using Agiil.BDD.Personas;
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

    [Given("Agiil has just been installed")]
    public void AgiilHasJustBeenInstalled()
    {
      testRunner.Value.Given("April can act as the application");

      var april = cast.Get<April>();

      Given(april).WasAbleTo<InstallTheApplication>();
    }

    public InstallationSteps(ICast cast, Lazy<ITestRunner> testRunner)
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
