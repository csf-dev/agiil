using System;
using System.Reflection;
using System.Web.Http;
using Agiil.Bootstrap;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace Agiil.Web.App_Start
{
  public static class DependencyInjectionConfig
  {
    public static IContainer GetDependencyInjectionContainer()
    {
      var builder = new ContainerBuilder();

      RegisterAspNetWebApiComponents(builder);

      RegisterAspNetMvcComponents(builder);

      RegisterApplicationComponents(builder);

      return builder.Build();
    }

    private static void RegisterAspNetMvcComponents(ContainerBuilder builder)
    {
      var mvcAssembly = GetMvcAssembly();

      builder.RegisterControllers(mvcAssembly);
      builder.RegisterModelBinders(mvcAssembly);
      builder.RegisterModelBinderProvider();
      builder.RegisterModule<AutofacWebTypesModule>();
    }

    private static Assembly GetMvcAssembly()
    {
      return typeof(Global).Assembly;
    }

    private static void RegisterAspNetWebApiComponents(ContainerBuilder builder)
    {
      var apiAssembly = GetWebApiAssembly();

      var config = GlobalConfiguration.Configuration;

      builder.RegisterApiControllers(apiAssembly);
      builder.RegisterWebApiFilterProvider(config);
    }

    private static Assembly GetWebApiAssembly()
    {
      return GetMvcAssembly();
    }

    private static void RegisterApplicationComponents(ContainerBuilder builder)
    {
      var bootstrapAssembly = GetBootstrapAssembly();

      builder.RegisterAssemblyModules(bootstrapAssembly);
    }

    private static Assembly GetBootstrapAssembly()
    {
      return typeof(IBootstrapAssemblyMarker).Assembly;
    }
  }
}
