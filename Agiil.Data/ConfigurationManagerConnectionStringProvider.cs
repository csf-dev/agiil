using System;
using System.Configuration;

namespace Agiil.Data
{
  public class ConfigurationManagerConnectionStringProvider : IConnectionStringProvider
  {
    public string GetConnectionString(string name)
    {
      return ConfigurationManager.ConnectionStrings[name]?.ConnectionString;
    }
  }
}
