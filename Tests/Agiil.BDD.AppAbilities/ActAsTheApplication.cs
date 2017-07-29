using System;
using CSF.Screenplay.Abilities;
using CSF.Screenplay.Actors;
using DeleporterCore.Client;

namespace Agiil.BDD.AppAbilities
{
  public class ActAsTheApplication : IAbility
  {
    public void Dispose()
    {
      // Intentional no-op
    }

    public void ExecuteAsAspplication(Action action)
    {
      Deleporter.Run(action);
    }

    public T ExecuteAsAspplication<T>(Func<T> function)
    {
      return Deleporter.Run(function);
    }

    public string GetReport(INamed actor) => $"{actor.Name} can act directly as the application.";
  }
}
