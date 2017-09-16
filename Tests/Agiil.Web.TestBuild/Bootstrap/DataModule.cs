using System;
using Agiil.Tests;
using Autofac;
using CSF.Data;
using CSF.Data.Entities;
using Agiil.Web.Data;
using Agiil.Data;
using Agiil.Data.Maintenance;

namespace Agiil.Web.Bootstrap
{
  public class DataModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<TestingDatabaseConfiguration>()
        .As<IDatabaseConfiguration>();

      builder
        .Register(BuildSnapshotDatabaseResetter)
        .As<IDatabaseResetter>();
    }

    SnapshottingDatabaseResetter BuildSnapshotDatabaseResetter(IComponentContext ctx)
    {
      var baseResetter = ctx.Resolve<DevelopmentDatabaseResetter>();
      var snapshotStore = ctx.Resolve<SnapshotStore>();
      var snapshotService = ctx.Resolve<ISnapshotService>();

      return new SnapshottingDatabaseResetter(baseResetter, snapshotStore, snapshotService);
    }
  }
}
