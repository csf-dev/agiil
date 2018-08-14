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

      builder
        .Register(GetBackupTakingUpgrader)
        .AsSelf()
        .As<IPerformsDatabaseUpgrades>();
      
      builder
        .RegisterConfiguration<DataDirectoryConfigurationSection>()
        .AsSelf()
        .As<IGetsDataDirectory>();
    }

    BackupTakingUpgrader GetBackupTakingUpgrader(IComponentContext c)
    {
      var innerUpgrader = c.Resolve<DbUpDatabaseUpgrader>();
      var backupService = c.Resolve<ITakesDatabaseBackup>();
      return new BackupTakingUpgrader(innerUpgrader, backupService);
    }
  }
}
