using System;
using Autofac;
using SpecFlow.Autofac;
using Agiil.Bootstrap;
using Agiil.Bootstrap.DiConfiguration;

namespace Agiil.BDD
{
  public class BddDependencies
  {
    static readonly IAutofacContainerBuilderFactory autofacContainerBuilderFactory;

    [ScenarioDependencies]
    public static ContainerBuilder CreateContainerBuilder()
    {
      return autofacContainerBuilderFactory.GetContainerBuilder();
    }

    static BddDependencies()
    {
      var provider = new ContainerBuilderFactoryProvider();
      autofacContainerBuilderFactory = provider.GetContainerBuilderFactory();
    }
  }
}
