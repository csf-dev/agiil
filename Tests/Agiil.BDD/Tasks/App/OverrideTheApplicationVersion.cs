using System;
using Agiil.BDD.ServiceEndpoints;
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using CSF.Screenplay.WebApis.Builders;

namespace Agiil.BDD.Tasks.App
{
  public class OverrideTheApplicationVersion : Performable
  {
    readonly string version;

    protected override string GetReport(INamed actor)
      => $"{actor.Name} overrides the application version to {version ?? "<null>"}";

    protected override void PerformAs(IPerformer actor)
    {
      actor.Perform(Invoke
                    .TheJsonWebService<OverrideVersionNumberService>()
                    .WithTheData(new { version })
                    .AndVerifyItSucceeds());
    }

    public OverrideTheApplicationVersion(string version)
    {
      this.version = version;
    }

    public static IPerformable To(string version) => new OverrideTheApplicationVersion(version);
  }
}
