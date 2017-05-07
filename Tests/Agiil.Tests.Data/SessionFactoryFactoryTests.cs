using System;
using System.Configuration;
using Agiil.Bootstrap;
using Agiil.Data;
using Autofac;
using NUnit.Framework;

namespace Agiil.Tests.Data
{
  [TestFixture]
  public class SessionFactoryFactoryTests
  {
    const string
      SchemaExportPathKey = "SchemaOutputPath",
      SchemaExportFallbackPath = "Agiil.schema.sql";

    IDiConfiguration containerBuilderFactory;
    ContainerBuilder builder;
    IContainer container;
    ILifetimeScope diScope;
    string schemaExportPath;

    [OneTimeSetUp]
    public void FixtureSetup()
    {
      containerBuilderFactory = new UnitTestDiConfiguration();
      builder = containerBuilderFactory.GetContainerBuilder();
      container = builder.Build();
      schemaExportPath = ConfigurationManager.AppSettings[SchemaExportPathKey]?? SchemaExportFallbackPath;
    }

    [SetUp]
    public void Setup()
    {
      diScope = container.BeginLifetimeScope();
    }

    [OneTimeTearDown]
    public void FixtureTeardown()
    {
      if(diScope != null)
      {
        diScope.Dispose();
        diScope = null;
      }

      if(container != null)
      {
        container.Dispose();
        container = null;
      }
    }

    [TearDown]
    public void Teardown()
    {
      if(diScope != null)
      {
        diScope.Dispose();
        diScope = null;
      }
    }

    [Test]
    public void Configuration_is_valid_nhibernate_configuration()
    {
      // Arrange
      var configurationCreator = diScope.Resolve<ISessionFactoryFactory>();

      // Act & assert
      Assert.DoesNotThrow(() => configurationCreator.GetConfiguration());
    }

    [Test]
    public void Configuration_can_build_session_factory()
    {
      // Arrange
      var configurationCreator = diScope.Resolve<ISessionFactoryFactory>();
      var configuration = configurationCreator.GetConfiguration();

      // Act & assert
      Assert.DoesNotThrow(() => configuration.BuildSessionFactory());
    }

    [Test]
    public void Application_can_export_database_schema()
    {
      // Arrange
      var databaseCreator = diScope.Resolve<IDatabaseCreator>();

      // Act & assert
      Assert.DoesNotThrow(() => databaseCreator.Create(schemaExportPath, true));
    }
  }
}
