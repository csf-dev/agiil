using System;
using Agiil.BDD.Actions;
using Agiil.Web.Services.DataPackages;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;

namespace Agiil.BDD.Tasks.App
{
  public class SetupTheSimpleSampleProject : Performable
  {
    protected override string GetReport(INamed actor) => $"{actor.Name} sets up the simple sample project";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(LoadTheDataPackage.Type<SimpleSampleProject>());
    }
  }
}
