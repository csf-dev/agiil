using System;
using Agiil.Data.Maintenance;
using Autofac;

namespace Agiil.Bootstrap.Data
{
  public class DatabaseMaintenanceModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<DevelopmentDatabaseResetter>()
        .As<IDatabaseResetter>();

      builder
        .RegisterType<DbUpDatabaseUpgrader>()
        .As<IDatabaseUpgrader>();

      builder
        .RegisterType<NHibernateSchemaExporter>()
        .As<IDbSchemaExporter>();
    }
  }
}
