﻿using System;
using System.Configuration;

namespace Agiil.Data
{
  public class ConfigurationManagerConnectionStringProvider : IConnectionStringProvider
  {
    readonly IDatabaseConfiguration dbConfig;

    public string GetConnectionString()
      => GetConnectionString(dbConfig.GetConnectionStringName());

    public string GetConnectionString(string name)
      => GetConnectionStringSettings(name)?.ConnectionString;

    public ConnectionStringSettings GetConnectionStringSettings()
      => GetConnectionStringSettings(dbConfig.GetConnectionStringName());

    public ConnectionStringSettings GetConnectionStringSettings(string name)
      => ConfigurationManager.ConnectionStrings[name];

    public ConfigurationManagerConnectionStringProvider(IDatabaseConfiguration dbConfig)
    {
      if(dbConfig == null)
        throw new ArgumentNullException(nameof(dbConfig));
      this.dbConfig = dbConfig;
    }
  }
}
