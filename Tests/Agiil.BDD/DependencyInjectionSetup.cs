using System;
using System.Linq;
using System.Reflection;
using Agiil.Bootstrap;
using Agiil.Web.App_Start;
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
      DependencyInjectionConfig.RegisterAspNetMvcComponents(builder);
      DependencyInjectionConfig.RegisterAspNetWebApiComponents(builder);
      builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

      return builder;
    }
  }
}
