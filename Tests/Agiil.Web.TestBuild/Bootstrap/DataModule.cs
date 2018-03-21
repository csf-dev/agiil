using System;
using Autofac;
using Agiil.Web.Data;
using Agiil.Data.Maintenance;
using Agiil.Domain.Data;
using Agiil.Data;

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
        .As<IResetsDatabase>();
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
