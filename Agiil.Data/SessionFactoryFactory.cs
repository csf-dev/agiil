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
    const string MappingName = "ConventionMappings";

    readonly IMappingProvider mappingProvider;
    readonly IConnectionStringProvider connectionStringProvider;

    public virtual ISessionFactory GetSessionFactory()
    {
      var config = GetConfiguration();
      return config.BuildSessionFactory();
    }

    public virtual Configuration GetConfiguration()
    {
      var config = new Configuration();

      ConfigureDatabase(config);
      ConfigureMappings(config);

      return config;
    }

    protected virtual void ConfigureMappings(Configuration config)
    {
      var mappings = mappingProvider.GetHbmMapping();
      config.AddDeserializedMapping(mappings, MappingName);
    }

    protected virtual void ConfigureDatabase(Configuration config)
    {
      var connectionString = connectionStringProvider.GetConnectionString();

      config.DataBaseIntegration(x => {
        x.SelectSQLiteDriver();
        x.Dialect<SQLiteDialect>();
        x.ConnectionString = connectionString;
      });
    }

    public SessionFactoryFactory(IMappingProvider mappingProvider,
                                 IConnectionStringProvider connectionStringProvider)
    {
      if(connectionStringProvider == null)
        throw new ArgumentNullException(nameof(connectionStringProvider));
      if(mappingProvider == null)
        throw new ArgumentNullException(nameof(mappingProvider));

      this.mappingProvider = mappingProvider;
      this.connectionStringProvider = connectionStringProvider;
    }
  }
}
