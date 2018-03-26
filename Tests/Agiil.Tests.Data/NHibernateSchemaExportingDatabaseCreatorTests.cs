using System;
using System.IO;
using Agiil.Bootstrap;
using Agiil.Data;
using Autofac;
using NUnit.Framework;

namespace Agiil.Tests.Data
{
  [TestFixture]
  public class NHibernateSchemaExportingDatabaseCreatorTests
  {
    const string SchemaExportFilename = "Agiil.db-schema-export.sql";

    [Test]
    public void Create_can_export_database_schema_without_errors()
    {
      var container = CachingDomainContainerFactory.Default.GetContainer();
      using(var scope = container.BeginLifetimeScope())
      {
        // Arrange
        var databaseCreator = scope.Resolve<NHibernateSchemaExportingDatabaseCreator>();
        var exportPath = GetSchemaExportPath();

        // Act & assert
        Assert.DoesNotThrow(() => databaseCreator.ExportToFile(exportPath));
      }
    }

    string GetSchemaExportPath()
    {
      var schemaExportDir = TestFilesystem.GetTestTemporaryDirectory<NHibernateSchemaExportingDatabaseCreatorTests>();
      if(schemaExportDir != null)
        return Path.Combine(schemaExportDir.FullName, SchemaExportFilename);
      else
        return SchemaExportFilename;
    }
  }
}
