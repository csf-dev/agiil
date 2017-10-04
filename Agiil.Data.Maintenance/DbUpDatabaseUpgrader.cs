using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DbUp;
using DbUp.Engine;
using log4net;

namespace Agiil.Data.Maintenance
{
  public class DbUpDatabaseUpgrader : IDatabaseUpgrader
  {
    static readonly ILog logger;

    readonly IConnectionStringProvider connectionStringProvider;
    readonly UpgradeEngine upgradeEngine;

    public DatabaseUpgradeResult ApplyAllUpgrades()
    {
      var result = upgradeEngine.PerformUpgrade();

      if(result.Error != null)
        logger.Error("Database upgrade process raised an error", result.Error);

      return new DatabaseUpgradeResult
      {
        Success = result.Successful,
        UpgradesApplied = result
          .Scripts
          .Select(x => new SimpleUpgradeName { Name = x.Name })
          .Cast<IUpgradeName>()
          .ToList(),
      };
    }

    public IList<IUpgradeName> GetAppliedUpgrades()
    {
      return upgradeEngine
        .GetExecutedScripts()
        .Select(x => new SimpleUpgradeName { Name = x })
        .Cast<IUpgradeName>()
        .ToList();
    }

    public IList<IUpgradeName> GetPendingUpgrades()
    {
      return upgradeEngine
        .GetScriptsToExecute()
        .Select(x => new SimpleUpgradeName { Name = x.Name })
        .Cast<IUpgradeName>()
        .ToList();
    }

    UpgradeEngine GetDbUpEngine()
    {
      return DeployChanges
        .To
        .SQLiteDatabase(connectionStringProvider.GetConnectionString())
        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
        .Build();
    }

    public DbUpDatabaseUpgrader(IConnectionStringProvider connectionStringProvider)
    {
      if(connectionStringProvider == null)
        throw new ArgumentNullException(nameof(connectionStringProvider));
      
      this.connectionStringProvider = connectionStringProvider;
      this.upgradeEngine = GetDbUpEngine();
    }

    static DbUpDatabaseUpgrader()
    {
      logger = LogManager.GetLogger(typeof(DbUpDatabaseUpgrader));
    }
  }
}
