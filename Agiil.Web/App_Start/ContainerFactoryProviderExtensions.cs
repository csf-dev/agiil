using System;
using System.Web.Http;
using Agiil.Bootstrap.DiConfiguration;
using Autofac;

namespace Agiil.Web.App_Start
{
  public static class ContainerFactoryProviderExtensions
  {
    public static IContainer GetContainer(this ContainerFactoryProvider provider, HttpConfiguration config)
    {
      if(provider == null)
        throw new ArgumentNullException(nameof(provider));
      if(config == null)
        throw new ArgumentNullException(nameof(config));

      var factoryProvider = new ContainerFactoryProvider();
      var diFactory = factoryProvider.GetContainerBuilderFactory() as IContainerFactoryWithHttpConfiguration;

      if(diFactory == null)
        throw new InvalidOperationException($"The configured container builder factory must implement {nameof(IContainerFactoryWithHttpConfiguration)}.");

      diFactory.SetHttpConfiguration(config);
      return diFactory.GetContainer();
    }
  }
}
