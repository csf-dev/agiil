using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using CSF.Data.NHibernate;
using NHibernate.Mapping.ByCode;
using CSF.Entities;
using Agiil.Domain;
using System.Linq;

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

      var mappings = GetMappings();

      config.AddDeserializedMapping(mappings, "ConventionMappings");

      config.DataBaseIntegration(x => {
        x.SelectSQLiteDriver();
        x.ConnectionString = "Data Source=Agiil.db;Version=3;";
      });

      return config;
    }

    private HbmMapping GetMappings()
    {
      var mapper = new ConventionModelMapper();

      mapper.IsEntity((type, declared) => BaseEntityType.IsAssignableFrom(type) && !type.IsInterface);

      var entityTypes = GetEntityTypes();

      return mapper.CompileMappingFor(entityTypes);
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
