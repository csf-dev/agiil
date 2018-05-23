using System;
namespace Agiil.Domain.Data
{
  public class ApplicationDependencyTester : ITestsApplicationDependencies
  {
    readonly ITestsThatDatabaseIsWorking databaseTester;
    readonly log4net.ILog logger;

    public AppDependencyTestResult TestApplicationDependencies()
    {
      var result = new AppDependencyTestResult {
        IsApplicationViableForMaintenance = true,
        IsApplicationOKToUse = true
      };

      PerformDatabaseChecks(result);

      return result;
    }

    void PerformDatabaseChecks(AppDependencyTestResult result)
    {
      PerformCriticalChecks(result);
      if(!result.IsApplicationViableForMaintenance) return;
      PerformMaintenanceChecks(result);
    }

    void PerformCriticalChecks(AppDependencyTestResult result)
    {
      result.ConnectionStringIsMissing = !databaseTester.IsConnectionStringAvailable();
      result.CannotConnectToDatabase = !databaseTester.IsDatabaseConnectionPossible();

      if(result.ConnectionStringIsMissing)
      {
        logger.Fatal("The application connection string is missing");
        result.IsApplicationViableForMaintenance = false;
        result.IsApplicationOKToUse = false;
      }

      if(result.CannotConnectToDatabase)
      {
        logger.Fatal("Cannot connect to the application database");
        result.IsApplicationViableForMaintenance = false;
        result.IsApplicationOKToUse = false;
      }
    }

    void PerformMaintenanceChecks(AppDependencyTestResult result)
    {
      result.DatabaseRequiresUpgrade = !databaseTester.IsDatabaseFullyUpgraded();

      if(result.DatabaseRequiresUpgrade)
      {
        logger.Error("The application database requires upgrades");
        result.IsApplicationOKToUse = false;
      }
    }

    public ApplicationDependencyTester(ITestsThatDatabaseIsWorking databaseTester)
    {
      if(databaseTester == null)
        throw new ArgumentNullException(nameof(databaseTester));
      
      this.databaseTester = databaseTester;
      logger = log4net.LogManager.GetLogger(GetType());
    }
  }
}
