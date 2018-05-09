using System;
using System.Collections.Generic;
using Agiil.Data.MappingProviders;
using CSF.Data.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;

namespace Agiil.Data
{
  public class SessionFactoryFactory : ISessionFactoryFactory
  {
    readonly IGetsHbmMapping mappingProvider;
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
      config.AddDeserializedMapping(mappings, mappingProvider.Name);
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

    public SessionFactoryFactory(IGetsHbmMapping mappingProvider,
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
