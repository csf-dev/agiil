using System;
using System.Configuration;
using System.Linq;
using Agiil.Domain.Data;
using CSF.Configuration.Data;

namespace Agiil.Data.Sqlite
{
  public class SqliteDatabaseTester : ITestsThatDatabaseIsWorking
  {
    readonly log4net.ILog logger;
    readonly Lazy<IConnectionStringProvider> connectionStringProvider;
    readonly Lazy<IPerformsDatabaseUpgrades> upgrader;

    protected IConnectionStringProvider ConnectionStringProvider
    {
      get {
        try
        {
          return connectionStringProvider.Value;
        }
        catch(Exception ex)
        {
          logger.Warn("Exception encountered whilst initialising the connection string provider");
          logger.Warn(ex);
          return null;
        }
      }
    }

    protected IPerformsDatabaseUpgrades Upgrader
    {
      get {
        try
        {
          return upgrader.Value;
        }
        catch(Exception ex)
        {
          logger.Warn("Exception encountered whilst initialising the database upgrader");
          logger.Warn(ex);
          return null;
        }
      }
    }

    protected ConnectionStringSettings ConnectionStringSettings
    {
      get {
        try
        {
          return ConnectionStringProvider?.GetConnectionStringSettings();
        }
        catch(Exception ex)
        {
          logger.Warn("Exception encountered whilst getting a connection string from the provider");
          logger.Warn(ex);
          return null;
        }
      }
    }

    public bool IsConnectionStringAvailable()
      => ConnectionStringSettings != null;

    public bool IsDatabaseConnectionPossible()
    {
      var connectionString = ConnectionStringSettings;
      if(connectionString == null)
      {
        logger.Warn("Could not test the database connection because no connection string is available");
        return false;
      }

      try
      {
        using(var connection = connectionString.CreateAndOpenConnection())
        {
          return (connection != null);
        }
      }
      catch(Exception ex)
      {
        logger.Warn("Exception encountered whilst testing database connection");
        logger.Warn(ex);
        return false;
      }
    }

    public bool IsDatabaseFullyUpgraded()
    {
      var dbUpgrader = Upgrader;
      if(dbUpgrader == null) return false;

      try
      {
        var upgradesToDo = dbUpgrader.GetPendingUpgrades();
        return !upgradesToDo.Any();
      }
      catch(Exception ex)
      {
        logger.Warn("Exception encountered whilst determining whether or not the database needs upgrades");
        logger.Warn(ex);
        return false;
      }
    }

    public SqliteDatabaseTester(Lazy<IConnectionStringProvider> connectionStringProvider,
                                Lazy<IPerformsDatabaseUpgrades> upgrader)
    {
      if(upgrader == null)
        throw new ArgumentNullException(nameof(upgrader));
      if(connectionStringProvider == null)
        throw new ArgumentNullException(nameof(connectionStringProvider));

      this.connectionStringProvider = connectionStringProvider;
      this.upgrader = upgrader;

      logger = log4net.LogManager.GetLogger(GetType());
    }
  }
}
