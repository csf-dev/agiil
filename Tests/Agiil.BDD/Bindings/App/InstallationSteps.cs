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

    public InstallationSteps(ICast cast, Lazy<AprilSteps> aprilSteps)
    {
      this.aprilSteps = aprilSteps ?? throw new ArgumentNullException(nameof(aprilSteps));
      this.cast = cast ?? throw new ArgumentNullException(nameof(cast));
    }
  }
}
