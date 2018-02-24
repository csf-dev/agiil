using System;
using Agiil.BDD.ServiceEndpoints;
using CSF.Screenplay.Actors;
using CSF.Screenplay.JsonApis.Abilities;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Actions
{
  public class InstallTheApplication : Performable
  {
    protected override string GetReport(INamed actor) => $"{actor.Name} installs Agiil at its standard initial state.";

    protected override void PerformAs(IPerformer actor)
    {
      var ability = actor.GetAbility<ConsumeJsonWebServices>();
      var invocation = new InstallAgiilService();
      ability.Execute(invocation);
    }
  }
}
