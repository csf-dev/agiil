using System;
using System.Net.Http;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.AppAbilities.Actions
{
  public abstract class ApplicationApiAction : Performable
  {
    protected override void PerformAs(IPerformer actor)
    {
      var ability = GetAbility(actor);
      var request = GetHttpRequest();
      ability.PerformRequest(request);
    }

    protected abstract HttpRequestMessage GetHttpRequest();

    protected virtual ActAsTheApplication GetAbility(IPerformer actor)
    {
      return actor.GetAbility<ActAsTheApplication>();
    }
  }
}
