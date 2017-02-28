using System;
using System.Reflection;
using Autofac;
using SpecFlow.Autofac;
using System.Linq;
using TechTalk.SpecFlow;
using Agiil.BDD.Impl;

namespace Agiil.BDD
{
  public static class BddDependencies
  {
    [ScenarioDependencies]
    public static ContainerBuilder CreateContainerBuilder()
    {
      return DependencyInjectionSetup.GetIntegrationTestContainerBuilder();
    }
  }
}
