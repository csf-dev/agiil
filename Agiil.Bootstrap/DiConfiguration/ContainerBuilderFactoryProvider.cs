using System;
using CSF.Configuration;

namespace Agiil.Bootstrap.DiConfiguration
{
  public class ContainerBuilderFactoryProvider
  {
    public IAutofacContainerBuilderFactory GetContainerBuilderFactory()
    {
      var config = GetConfig();
      if(config == null)
        throw new InvalidOperationException($"The configuration file must include {nameof(DiConfigurationSection)}.");

      var factoryType = GetFactoryType(config.FactoryTypeName);
      if(factoryType == null)
        throw new InvalidOperationException($"The {nameof(DiConfigurationSection)} must specify a factory type which exists.");

      var factory = GetFactory(factoryType);
      if(factory == null)
        throw new InvalidOperationException($"An unexpected error occured whilst creating an instance of {factoryType.FullName}.");

      return factory;
    }

    Type GetFactoryType(string typeName)
    {
      return Type.GetType(typeName);
    }

    DiConfigurationSection GetConfig()
    {
      var reader = new ConfigurationReader();
      return reader.ReadSection<DiConfigurationSection>();
    }

    IAutofacContainerBuilderFactory GetFactory(Type factoryType)
    {
      return (IAutofacContainerBuilderFactory) Activator.CreateInstance(factoryType);
    }
  }
}
