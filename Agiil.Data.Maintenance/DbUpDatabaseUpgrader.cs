using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using DbUp;
using DbUp.Engine;

namespace Agiil.Data.Maintenance
{
  public class DbUpDatabaseUpgrader : IDatabaseUpgrader
  {
    readonly IConnectionStringProvider connectionStringProvider;

    public DatabaseUpgradeResult ApplyAllUpgrades()
    {
      var engine = GetDbUpEngine();
      var result = engine.PerformUpgrade();

      // TODO: Improve this when (at some point) we have proper error/diagnostic logging implemented.
      #if DEBUG
      Console.WriteLine(result.Error);
      #endif

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
      var engine = GetDbUpEngine();
      return engine
        .GetExecutedScripts()
        .Select(x => new SimpleUpgradeName { Name = x })
        .Cast<IUpgradeName>()
        .ToList();
    }

    public IList<IUpgradeName> GetPendingUpgrades()
    {
      var engine = GetDbUpEngine();
      return engine
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
    }
  }
}
