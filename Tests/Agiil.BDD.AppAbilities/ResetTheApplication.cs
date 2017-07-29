using System;
using Agiil.Web.TestBuild;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.AppAbilities
{
  public class ResetTheApplication : AppAction
  {
    protected override string GetReport(INamed actor) => $"{actor.Name} resets the application to its initial state.";

    protected override void PerformAs(IPerformer actor, ActAsTheApplication ability)
    {
      ability.ExecuteAsAspplication(() => InMemoryDatabase.Current.Reset());
    }

    public static IPerformable Now()
    {
      return new ResetTheApplication();
    }
  }
}
