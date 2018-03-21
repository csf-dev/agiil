using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Agiil.Domain.Data;
using DbUp;
using DbUp.Engine;
using log4net;

namespace Agiil.Data.Maintenance
{
  public class DbUpDatabaseUpgrader : IPerformsDatabaseUpgrades
  {
    static readonly ILog logger;

    readonly IConnectionStringProvider connectionStringProvider;
    readonly UpgradeEngine upgradeEngine;

    public Domain.Data.DatabaseUpgradeResult ApplyAllUpgrades()
    {
      var result = upgradeEngine.PerformUpgrade();

      var output = new Domain.Data.DatabaseUpgradeResult
      {
        Success = result.Successful,
        UpgradesApplied = result
          .Scripts
          .Select(x => new SimpleUpgradeName { Name = x.Name })
          .Cast<IUpgradeName>()
          .ToList(),
      };

      LogCompletion(output, result.Error);

      return output;
    }

    void LogCompletion(Domain.Data.DatabaseUpgradeResult result, Exception exception)
    {
      string message;

      if(exception != null)
        message = "Completed database upgrade process, with errors";
      else
        message = "Completed database upgrade process successfully";

      logger.Info(message);
      logger.Info(result);

      if(exception != null)
        logger.Error("The database upgrade process raised an exception", exception);
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
