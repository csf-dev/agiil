using System;
using Autofac;
using SpecFlow.Autofac;
using Agiil.Bootstrap;

namespace Agiil.BDD
{
  public class BddDependencies
  {
    static readonly IDiConfiguration autofacContainerBuilderFactory;

    [ScenarioDependencies]
    public static ContainerBuilder CreateContainerBuilder()
    {
      return autofacContainerBuilderFactory.GetContainerBuilder();
    }

    static BddDependencies()
    {
      autofacContainerBuilderFactory = new BddTestDiConfiguration();
    }
  }
}
