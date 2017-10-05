using System;
using Agiil.BDD.Abilities;
using Agiil.BDD.Actions;
using CSF.Screenplay;
using TechTalk.SpecFlow;
using static CSF.Screenplay.StepComposer;

namespace Agiil.BDD.Bindings.App
{
  [Binding]
  public class InstallationSteps
  {
    readonly IScreenplayScenario screenplay;

    [Given("Agiil has just been installed")]
    public void AgiilHasJustBeenInstalled()
    {
      var april = screenplay.GetApril();

      Given(april).WasAbleTo<InstallTheApplication>();
    }

    public InstallationSteps(IScreenplayScenario screenplay)
    {
      if(screenplay == null)
        throw new ArgumentNullException(nameof(screenplay));
      
      this.screenplay = screenplay;
    }
  }
}
