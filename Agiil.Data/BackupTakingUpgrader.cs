using System;
using System.Collections.Generic;
using Agiil.Domain.Data;

namespace Agiil.Data
{
  public class BackupTakingUpgrader : IPerformsDatabaseUpgrades
  {
    readonly IPerformsDatabaseUpgrades proxiedUpgrader;
    readonly ITakesDatabaseBackup backupService;

    public DatabaseUpgradeResult ApplyAllUpgrades()
    {
      backupService.TakeDatabaseBackup("Pre-upgrade");
      return proxiedUpgrader.ApplyAllUpgrades();
    }

    public IList<IUpgradeName> GetAppliedUpgrades()
    {
      return proxiedUpgrader.GetAppliedUpgrades();
    }

    public IList<IUpgradeName> GetPendingUpgrades()
    {
      return proxiedUpgrader.GetPendingUpgrades();
    }

    public BackupTakingUpgrader(IPerformsDatabaseUpgrades proxiedUpgrader,
                                ITakesDatabaseBackup backupService)
    {
      if(backupService == null)
        throw new ArgumentNullException(nameof(backupService));
      if(proxiedUpgrader == null)
        throw new ArgumentNullException(nameof(proxiedUpgrader));
      this.backupService = backupService;
      this.proxiedUpgrader = proxiedUpgrader;
    }
  }
}
