using System;
using Autofac;
using CSF.Screenplay.Actors;

namespace Agiil.BDD.Bootstrap
{
  public class ScreenplayModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<ReportingCast>()
        .As<ICast>()
        .InstancePerLifetimeScope();

    }
  }
}
