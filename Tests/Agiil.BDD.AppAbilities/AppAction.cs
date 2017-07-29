using System;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.AppAbilities
{
  public abstract class AppAction : Performable
  {
    protected override void PerformAs(IPerformer actor)
    {
      var ability = GetAbility(actor);
      PerformAs(actor, ability);
    }

    protected abstract void PerformAs(IPerformer actor, ActAsTheApplication ability);

    protected virtual ActAsTheApplication GetAbility(IPerformer actor)
    {
      return actor.GetAbility<ActAsTheApplication>();
    }
  }
}
