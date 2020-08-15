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
                var needsUpgrades = upgradesToDo.Any();

                if(needsUpgrades && logger.IsDebugEnabled)
                {
                    logger.Debug($@"{nameof(IsDatabaseFullyUpgraded)} - {upgradesToDo.Count} {(upgradesToDo.Count == 1 ? "upgrade" : "upgrades")} are required:
{String.Join(Environment.NewLine, upgradesToDo.Select(x => $"* {x.GetName()}"))}");
                }

                return !needsUpgrades;
            }
            catch(Exception ex)
            {
                logger.Warn("Exception encountered whilst determining whether or not the database needs upgrades");
                logger.Warn(ex);
                return false;
            }
        }

        public SqliteDatabaseTester(Lazy<IConnectionStringProvider> connectionStringProvider,
                                    Lazy<IPerformsDatabaseUpgrades> upgrader,
                                    log4net.ILog logger)
        {
            this.connectionStringProvider = connectionStringProvider ?? throw new ArgumentNullException(nameof(connectionStringProvider));
            this.upgrader = upgrader ?? throw new ArgumentNullException(nameof(upgrader));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
