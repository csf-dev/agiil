using System;
using CSF.Configuration;

namespace Agiil.Bootstrap.DiConfiguration
{
  public class ContainerFactoryProvider
  {
    public IAutofacContainerFactory GetContainerBuilderFactory()
    {
      var config = GetConfig();
      if(config == null)
        throw new InvalidOperationException($"The configuration file must include {nameof(DiConfigurationSection)}.");

      var factoryType = GetFactoryType(config.FactoryTypeName);
      if(factoryType == null)
        throw new InvalidOperationException($"The {nameof(DiConfigurationSection)} must specify a factory type which exists.\n" +
                                            $"The type '{config.FactoryTypeName}' was not found.");

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

    IAutofacContainerFactory GetFactory(Type factoryType)
    {
      return (IAutofacContainerFactory) Activator.CreateInstance(factoryType);
    }
  }
}
