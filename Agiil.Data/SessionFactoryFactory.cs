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
using System.Reflection;

namespace Agiil.Data
{
  public class SessionFactoryFactory : ISessionFactoryFactory
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

      mapper.IsRootEntity((type, declared) => type.BaseType == null
                                              || IsEntityBaseType(type.BaseType));

      mapper.IsEntity((type, declared) => BaseEntityType.IsAssignableFrom(type)
                                          && type.IsClass);

      mapper.BeforeMapClass += (modelInspector, type, classCustomizer) => {
        classCustomizer.Id(type.GetProperty("IdentityValue",
                                            BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic),
                           m => {
          m.Type(new NHibernate.Type.Int64Type());
          m.Column("id");
        });
      };

      mapper.IsPersistentProperty((member, declared) => {
        var property = member as PropertyInfo;

        if(property == null || !property.CanRead || !property.CanWrite)
        {
          return false;
        }

        if(property.Name == "IdentityValue"
           && property.PropertyType == typeof(long)
           && property.DeclaringType == typeof(Entity<long>))
        {
          return false;
        }

        return true;
      });

      var entityTypes = GetEntityTypes();

      return mapper.CompileMappingFor(entityTypes);
    }

    private bool IsEntityBaseType(Type type)
    {
      var result = (type.IsGenericType
                    && type.GetGenericTypeDefinition() == typeof(Entity<>))
                   || (type.IsGenericTypeDefinition
                       && type == typeof(Entity<>));

      return result;
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
