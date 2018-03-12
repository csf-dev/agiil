using System;
using Agiil.BDD.ServiceEndpoints;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.WebApis.Builders;

namespace Agiil.BDD.Actions
{
  public class InstallTheApplication : Performable
  {
    protected override string GetReport(INamed actor) => $"{actor.Name} installs Agiil at its standard initial state.";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Invoke.TheJsonWebService<InstallAgiilService>().AndVerifyItSucceeds());
    }
  }
}
