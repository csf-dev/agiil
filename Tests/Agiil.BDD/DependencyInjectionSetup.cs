using System;
using System.Reflection;
using Agiil.Bootstrap;
using Autofac;
using SpecFlow.Autofac;
using System.Linq;
using TechTalk.SpecFlow;

namespace Agiil.BDD
{
  public static class DependencyInjectionSetup
  {
    [ScenarioDependencies]
    public static ContainerBuilder CreateContainerBuilder()
    {
      var builder = new ContainerBuilder();

      builder.RegisterAssemblyModules(typeof(IBootstrapAssemblyMarker).Assembly);

      var bindingTypes = Assembly.GetExecutingAssembly()
        .GetExportedTypes()
        .Where(x => Attribute.IsDefined(x, typeof(BindingAttribute)))
        .ToArray();

      builder.RegisterTypes(bindingTypes).AsSelf().InstancePerLifetimeScope();

      return builder;
    }
  }
}
