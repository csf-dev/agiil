using System;
using Agiil.Data;
using Agiil.Data.Sqlite;
using Agiil.Domain.Data;
using Agiil.Tests.Attributes;
using Moq;
using NUnit.Framework;
using System.Configuration;
using CSF.Reflection;
using System.IO;
using log4net;

namespace Agiil.Tests.Data
{
  [TestFixture]
  public class SqliteDatabaseTesterTests
  {
    const string
      ConnStringName = "Sample connection string",
      MonoSqliteProviderName = "Mono.Data.Sqlite",
      NonExistentDirectoryName = "_zzz_nonexistent_",
      DatabaseFilename = "Database.db";

    string invalidDbPath, validDbPath, providerName;

    [SetUp]
    public void Setup()
    {
      var basePath = TestFilesystem.GetTestTemporaryDirectory<SqliteDatabaseTesterTests>();
      invalidDbPath = Path.Combine(basePath.FullName, NonExistentDirectoryName, DatabaseFilename);
      validDbPath = Path.Combine(basePath.FullName, DatabaseFilename);

      providerName = Reflect.IsMono()? MonoSqliteProviderName : typeof(System.Data.SQLite.SQLiteFactory).Namespace;
    }

    [Test,AutoMoqData]
    public void IsConnectionStringAvailable_returns_true_if_connection_string_is_not_null(IConnectionStringProvider connectionStringProvider,
                                                                                          IPerformsDatabaseUpgrades upgrader,
                                                                                          ConnectionStringSettings connStr,
                                                                                          ILog logger)
    {
      // Arrange
      Mock.Get(connectionStringProvider).Setup(x => x.GetConnectionStringSettings()).Returns(connStr);
      var sut = new SqliteDatabaseTester(new Lazy<IConnectionStringProvider>(() => connectionStringProvider),
                                         new Lazy<IPerformsDatabaseUpgrades>(() => upgrader),
                                         logger);

      // Act
      var result = sut.IsConnectionStringAvailable();

      // Assert
      Assert.That(result, Is.True);
    }

    [Test,AutoMoqData]
    public void IsConnectionStringAvailable_returns_false_if_connection_string_is_null(IConnectionStringProvider connectionStringProvider,
                                                                                       IPerformsDatabaseUpgrades upgrader,
                                                                                       ILog logger)
    {
      // Arrange
      Mock.Get(connectionStringProvider).Setup(x => x.GetConnectionStringSettings()).Returns(() => null);
      var sut = new SqliteDatabaseTester(new Lazy<IConnectionStringProvider>(() => connectionStringProvider),
                                         new Lazy<IPerformsDatabaseUpgrades>(() => upgrader),
                                         logger);

      // Act
      var result = sut.IsConnectionStringAvailable();

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void IsConnectionStringAvailable_returns_false_if_connection_string_getter_throws_an_exception(IConnectionStringProvider connectionStringProvider,
                                                                                                         IPerformsDatabaseUpgrades upgrader,
                                                                                                          ILog logger)
    {
      // Arrange
      Mock.Get(connectionStringProvider).Setup(x => x.GetConnectionStringSettings()).Throws<Exception>();
      var sut = new SqliteDatabaseTester(new Lazy<IConnectionStringProvider>(() => connectionStringProvider),
                                         new Lazy<IPerformsDatabaseUpgrades>(() => upgrader),
                                         logger);

      // Act
      var result = sut.IsConnectionStringAvailable();

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void IsConnectionStringAvailable_returns_false_if_lazy_connection_string_provider_returns_null(IPerformsDatabaseUpgrades upgrader,
                                                                                                          ILog logger)
    {
      // Arrange
      var sut = new SqliteDatabaseTester(new Lazy<IConnectionStringProvider>(() => null),
                                         new Lazy<IPerformsDatabaseUpgrades>(() => upgrader),
                                         logger);

      // Act
      var result = sut.IsConnectionStringAvailable();

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void IsConnectionStringAvailable_returns_false_if_lazy_connection_string_provider_throws_exception(IPerformsDatabaseUpgrades upgrader,
                                                                                                              ILog logger)
    {
      // Arrange
      var sut = new SqliteDatabaseTester(new Lazy<IConnectionStringProvider>(() => { throw new Exception(); }),
                                         new Lazy<IPerformsDatabaseUpgrades>(() => upgrader),
                                         logger);

      // Act
      var result = sut.IsConnectionStringAvailable();

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void IsDatabaseFullyUpgraded_returns_false_if_lazy_upgrader_throws_exception(IConnectionStringProvider connectionStringProvider,
                                                                                        ILog logger)
    {
      // Arrange
      var sut = new SqliteDatabaseTester(new Lazy<IConnectionStringProvider>(() => connectionStringProvider),
                                         new Lazy<IPerformsDatabaseUpgrades>(() => { throw new Exception(); }),
                                         logger);

      // Act
      var result = sut.IsDatabaseFullyUpgraded();

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void IsDatabaseFullyUpgraded_returns_false_if_upgrader_throws_exception(IConnectionStringProvider connectionStringProvider,
                                                                                   IPerformsDatabaseUpgrades upgrader,
                                                                                   ILog logger)
    {
      // Arrange
      Mock.Get(upgrader).Setup(x => x.GetPendingUpgrades()).Throws<Exception>();
      var sut = new SqliteDatabaseTester(new Lazy<IConnectionStringProvider>(() => connectionStringProvider),
                                         new Lazy<IPerformsDatabaseUpgrades>(() => upgrader),
                                         logger);

      // Act
      var result = sut.IsDatabaseFullyUpgraded();

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void IsDatabaseFullyUpgraded_returns_false_if_upgrader_returns_upgrades_to_be_done(IConnectionStringProvider connectionStringProvider,
                                                                                              IPerformsDatabaseUpgrades upgrader,
                                                                                              IUpgradeName upgrade,
                                                                                              ILog logger)
    {
      // Arrange
      Mock.Get(upgrader).Setup(x => x.GetPendingUpgrades()).Returns(new [] { upgrade });
      var sut = new SqliteDatabaseTester(new Lazy<IConnectionStringProvider>(() => connectionStringProvider),
                                         new Lazy<IPerformsDatabaseUpgrades>(() => upgrader),
                                         logger);

      // Act
      var result = sut.IsDatabaseFullyUpgraded();

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void IsDatabaseFullyUpgraded_returns_true_if_upgrader_returns_empty_set_of_upgrades(IConnectionStringProvider connectionStringProvider,
                                                                                               IPerformsDatabaseUpgrades upgrader,
                                                                                               ILog logger)
    {
      // Arrange
      Mock.Get(upgrader).Setup(x => x.GetPendingUpgrades()).Returns(new IUpgradeName[0]);
      var sut = new SqliteDatabaseTester(new Lazy<IConnectionStringProvider>(() => connectionStringProvider),
                                         new Lazy<IPerformsDatabaseUpgrades>(() => upgrader),
                                         logger);

      // Act
      var result = sut.IsDatabaseFullyUpgraded();

      // Assert
      Assert.That(result, Is.True);
    }

    [Test,AutoMoqData]
    public void IsDatabaseConnectionPossible_returns_false_if_connection_string_is_null(IConnectionStringProvider connectionStringProvider,
                                                                                        IPerformsDatabaseUpgrades upgrader,
                                                                                        ILog logger)
    {
      // Arrange
      Mock.Get(connectionStringProvider).Setup(x => x.GetConnectionStringSettings()).Returns(() => null);
      var sut = new SqliteDatabaseTester(new Lazy<IConnectionStringProvider>(() => connectionStringProvider),
                                         new Lazy<IPerformsDatabaseUpgrades>(() => upgrader),
                                         logger);

      // Act
      var result = sut.IsDatabaseConnectionPossible();

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void IsDatabaseConnectionPossible_returns_false_if_connection_string_is_invalid(IConnectionStringProvider connectionStringProvider,
                                                                                           IPerformsDatabaseUpgrades upgrader,
                                                                                           ILog logger)
    {
      // Arrange
      // Note that this assumption would fail for Mono on Windows, but not important enough to over-engineer
      var dataSource = invalidDbPath;
      var invalidConnectionString = GetSqliteConnectionString(dataSource);

      Mock.Get(connectionStringProvider)
          .Setup(x => x.GetConnectionStringSettings())
          .Returns(() => new ConnectionStringSettings(ConnStringName, invalidConnectionString, providerName));
      var sut = new SqliteDatabaseTester(new Lazy<IConnectionStringProvider>(() => connectionStringProvider),
                                         new Lazy<IPerformsDatabaseUpgrades>(() => upgrader),
                                         logger);

      // Act
      var result = sut.IsDatabaseConnectionPossible();

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void IsDatabaseConnectionPossible_returns_true_if_connection_string_is_valid(IConnectionStringProvider connectionStringProvider,
                                                                                        IPerformsDatabaseUpgrades upgrader,
                                                                                        ILog logger)
    {
      // Arrange
      var dataSource = validDbPath;
      var connectionString = GetSqliteConnectionString(dataSource);

      Mock.Get(connectionStringProvider)
          .Setup(x => x.GetConnectionStringSettings())
          .Returns(() => new ConnectionStringSettings(ConnStringName, connectionString, providerName));
      var sut = new SqliteDatabaseTester(new Lazy<IConnectionStringProvider>(() => connectionStringProvider),
                                         new Lazy<IPerformsDatabaseUpgrades>(() => upgrader),
                                         logger);

      // Act
      var result = sut.IsDatabaseConnectionPossible();

      // Assert
      Assert.That(result, Is.True);
    }

    string GetSqliteConnectionString(string dataSource)
      => $"Data Source={dataSource};Version=3;";
  }
}
