using System;
using Agiil.Data;
using Agiil.Domain.Data;
using Autofac;
using CSF.DecoratorBuilder;

namespace Agiil.Bootstrap.Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder
              .RegisterType<SnapshotStore>()
              .SingleInstance();

            builder.RegisterDecoratedService<IPerformsDatabaseUpgrades>(d => d
                .UsingInitialImpl<DbUpDatabaseUpgrader>()
                .ThenWrapWith<BackupTakingUpgrader>());

            builder
              .RegisterConfiguration<DataDirectoryConfigurationSection>()
              .AsSelf()
              .As<IGetsDataDirectory>();
        }
    }
}
