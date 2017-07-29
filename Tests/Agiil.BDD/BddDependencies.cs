using System;
using Autofac;
using SpecFlow.Autofac;
using Agiil.Bootstrap;
using Agiil.Bootstrap.DiConfiguration;

namespace Agiil.BDD
{
  public class BddDependencies
  {
    static readonly IAutofacContainerFactory autofacContainerBuilderFactory;

    [ScenarioDependencies]
    public static ContainerBuilder CreateContainerBuilder()
    {
      return autofacContainerBuilderFactory.GetContainerBuilder();
    }

    static BddDependencies()
    {
      var provider = new ContainerFactoryProvider();
      autofacContainerBuilderFactory = provider.GetContainerBuilderFactory();
    }
  }
}
