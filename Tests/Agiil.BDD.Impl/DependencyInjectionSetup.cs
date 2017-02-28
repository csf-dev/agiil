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

      builder.RegisterAssemblyModules(typeof(IBootstrapAssemblyMarker).Assembly);

      var bindingTypes = Assembly.GetAssembly(typeof(IBddAssemblyMarker))
                                 .GetExportedTypes()
                                 .Where(x => Attribute.IsDefined(x, typeof(BindingAttribute)))
                                 .ToArray();

      builder.RegisterTypes(bindingTypes).AsSelf().InstancePerLifetimeScope();

      builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

      return builder;
    }
  }
}
