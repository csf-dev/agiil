using System;
using CSF.Configuration;

namespace Agiil.Bootstrap.DiConfiguration
{
  public class ContainerFactoryProvider
  {
    public IGetsAutofacContainer GetContainerBuilderFactory()
    {
      var factoryType = GetFactoryType();

      return GetFactory(factoryType);
    }

    Type GetFactoryType()
    {
      var config = GetConfig();

      if(config != null)
        return Type.GetType(config.FactoryTypeName);

      return typeof(DomainContainerFactory);
    }

    DiConfigurationSection GetConfig()
    {
      var reader = new ConfigurationReader();
      return reader.ReadSection<DiConfigurationSection>();
    }

    IGetsAutofacContainer GetFactory(Type factoryType)
    {
      if(factoryType == null)
        throw new ArgumentNullException(nameof(factoryType));

      return (IGetsAutofacContainer) Activator.CreateInstance(factoryType);
    }
  }
}
