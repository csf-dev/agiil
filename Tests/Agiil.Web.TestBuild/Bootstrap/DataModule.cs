using System;
using Autofac;
using Agiil.Web.Data;
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

      builder.Register(BuildSnapshotDatabaseResetter);
    }

    IResetsDatabase BuildSnapshotDatabaseResetter(IComponentContext ctx)
    {
      var factory = ctx.Resolve<Func<IResetsDatabase,SnapshottingDatabaseResetter>>();
      var baseResetter = ctx.Resolve<DevelopmentDatabaseResetter>();
      return factory(baseResetter);
    }
  }
}
