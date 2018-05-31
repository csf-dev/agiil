using System;
namespace Agiil.Domain.Data
{
  /// <summary>
  /// This service tests that the database is viable - that we can connect to it and that it is up to date
  /// with required upgrades.
  /// </summary>
  public interface ITestsThatDatabaseIsWorking
  {
    bool IsConnectionStringAvailable();

    bool IsDatabaseConnectionPossible();

    bool IsDatabaseFullyUpgraded();
  }
}
