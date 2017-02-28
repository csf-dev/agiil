using System;
using System.Linq;
using System.Reflection;
using Agiil.Bootstrap;
using Autofac;
using TechTalk.SpecFlow;

namespace Agiil.BDD.Impl
{
  public static class DependencyInjectionSetup
  {
    public static ContainerBuilder GetIntegrationTestContainerBuilder()
    {
      var builder = new ContainerBuilder();

      builder.RegisterAssemblyModules(Assembly.GetAssembly(typeof(IBootstrapAssemblyMarker)));
      builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

      return builder;
    }
  }
}
