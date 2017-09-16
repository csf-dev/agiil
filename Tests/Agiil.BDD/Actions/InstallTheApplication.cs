using System;
using Agiil.Web.Controllers;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Actions
{
  public class InstallTheApplication : ApplicationApiAction
  {
    protected override string GetReport(INamed actor) => $"{actor.Name} installs Agiil at its standard initial state.";

    protected override string GetControllerName() => nameof(InstallAgiilController);
  }
}
