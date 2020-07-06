using System;
using Autofac;
using Agiil.Domain.Data;
using Agiil.Tests.Data;
using Agiil.Data;

namespace Agiil.Tests.Bootstrap
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
            var factory = ctx.Resolve<Func<IResetsDatabase, SnapshottingDatabaseResetter>>();
            var baseResetter = ctx.Resolve<DevelopmentDatabaseResetter>();
            return factory(baseResetter);
        }
    }
}
