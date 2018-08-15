using System;
using Agiil.Data;
using Agiil.Domain.Data;
using Autofac;

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

      builder.Register(GetBackupTakingUpgrader);
      
      builder
        .RegisterConfiguration<DataDirectoryConfigurationSection>()
        .AsSelf()
        .As<IGetsDataDirectory>();
    }

    IPerformsDatabaseUpgrades GetBackupTakingUpgrader(IComponentContext c)
    {
      var factory = c.Resolve<Func<IPerformsDatabaseUpgrades,BackupTakingUpgrader>>();
      var innerUpgrader = c.Resolve<DbUpDatabaseUpgrader>();
      return factory(innerUpgrader);
    }
  }
}
