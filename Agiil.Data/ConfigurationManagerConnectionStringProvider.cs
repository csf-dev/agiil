using System;
using System.Configuration;

namespace Agiil.Data
{
  public class ConfigurationManagerConnectionStringProvider : IConnectionStringProvider
  {
    readonly IDatabaseConfiguration dbConfig;

    public string GetConnectionString()
    {
      return GetConnectionString(dbConfig.GetConnectionStringName());
    }

    public string GetConnectionString(string name)
    {
      return ConfigurationManager.ConnectionStrings[name]?.ConnectionString;
    }

    public ConfigurationManagerConnectionStringProvider(IDatabaseConfiguration dbConfig)
    {
      if(dbConfig == null)
        throw new ArgumentNullException(nameof(dbConfig));
      this.dbConfig = dbConfig;
    }
  }
}
