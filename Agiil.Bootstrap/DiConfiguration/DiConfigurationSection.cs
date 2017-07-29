using System;
using System.Configuration;
using CSF.Configuration;

namespace Agiil.Bootstrap.DiConfiguration
{
  [ConfigurationPath("Agiil/DiConfiguration")]
  public class DiConfigurationSection : ConfigurationSection
  {
    const string FactoryTypeNameConfigName = @"FactoryTypeName";

    [ConfigurationProperty(FactoryTypeNameConfigName, IsRequired = true)]
    public virtual string FactoryTypeName
    {
      get { return (string) this[FactoryTypeNameConfigName]; }
      set { this[FactoryTypeNameConfigName] = value; }
    }
  }
}
