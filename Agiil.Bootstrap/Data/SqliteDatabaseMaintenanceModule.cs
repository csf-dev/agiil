using System;
using System.Collections.Generic;
using System.Reflection;
using Agiil.Data.Maintenance.Sqlite;
using Autofac;

namespace Agiil.Bootstrap.Data
{
  public class SqliteDatabaseMaintenanceModule : NamespaceModule
  {
    static readonly Type NamespaceMarkerType = typeof(SnapshotService);

    protected override string Namespace => NamespaceMarkerType.Namespace;

    protected override IEnumerable<Assembly> GetSearchAssemblies()
    {
      return new [] {
        NamespaceMarkerType.Assembly
      };
    }
  }
}
