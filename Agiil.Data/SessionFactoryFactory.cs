using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using CSF.Data.NHibernate;
using NHibernate.Mapping.ByCode;
using CSF.Entities;
using Agiil.Domain;
using System.Linq;
using NHibernate.Dialect;

namespace Agiil.Data
{
  public class SessionFactoryFactory
  {
    static readonly Type BaseEntityType = typeof(IEntity);

    public ISessionFactory GetSessionFactory()
    {
      var config = GetConfiguration();
      return config.BuildSessionFactory();
    }

    public Configuration GetConfiguration()
    {
      var config = new Configuration();

      config.DataBaseIntegration(x => {
        x.SelectSQLiteDriver();
        x.Dialect<SQLiteDialect>();
        x.ConnectionString = "Data Source=Agiil.db;Version=3;";
      });

      var mappings = GetMappings();

      config.AddDeserializedMapping(mappings, "ConventionMappings");

      return config;
    }

    private HbmMapping GetMappings()
    {
      var mapper = new ConventionModelMapper();

      mapper.IsEntity((type, declared) => BaseEntityType.IsAssignableFrom(type)
                                          && type.IsClass
                                          && !IsRootEntityType(type));
      mapper.IsRootEntity((type, declared) => IsRootEntityType(type));

      var entityTypes = GetEntityTypes();

      return mapper.CompileMappingFor(entityTypes);
    }

    private bool IsRootEntityType(Type type)
    {
      return BaseEntityType.IsAssignableFrom(type)
             && type.IsGenericType
             && type.GetGenericTypeDefinition() == typeof(Entity<>);
    }

    private Type[] GetEntityTypes()
    {
      var domainAssembly = typeof(IDomainAssemblyMarker).Assembly;

      return (from type in domainAssembly.GetExportedTypes()
              where
                BaseEntityType.IsAssignableFrom(type)
                && type.IsClass
              select type)
        .ToArray();
    }
  }
}
