using System;
using System.Reflection;
using System.Web.Http;
using Agiil.Bootstrap;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace Agiil.Web.App_Start
{
  public class AutofacContainerFactory
  {
    #region public API

    public virtual IContainer GetContainer(HttpConfiguration config)
    {
      var builder = GetContainerBuilder();

      RegisterAspNetWebApiComponents(builder, config);

      RegisterAspNetMvcComponents(builder);

      RegisterApplicationComponents(builder);

      return builder.Build();
    }

    public virtual void RegisterAspNetMvcComponents(ContainerBuilder builder)
    {
      var mvcAssembly = GetMvcAssembly();

      builder.RegisterControllers(mvcAssembly);
      builder.RegisterModelBinders(mvcAssembly);
      builder.RegisterModelBinderProvider();
      builder.RegisterModule<AutofacWebTypesModule>();
    }

    public virtual void RegisterAspNetWebApiComponents(ContainerBuilder builder, HttpConfiguration config)
    {
      var apiAssembly = GetWebApiAssembly();

      builder.RegisterApiControllers(apiAssembly);
      builder.RegisterWebApiFilterProvider(config);
    }

    public virtual void RegisterApplicationComponents(ContainerBuilder builder)
    {
      var bootstrapAssembly = GetBootstrapAssembly();
      var thisAssembly = Assembly.GetExecutingAssembly();

      builder.RegisterAssemblyModules(bootstrapAssembly);
      builder.RegisterAssemblyModules(thisAssembly);
    }

    public virtual ContainerBuilder GetContainerBuilder()
    {
      return new ContainerBuilder();
    }

    #endregion

    #region methods

    protected virtual Assembly GetMvcAssembly()
    {
      return typeof(Global).Assembly;
    }

    protected virtual Assembly GetWebApiAssembly()
    {
      return GetMvcAssembly();
    }

    protected virtual Assembly GetBootstrapAssembly()
    {
      return typeof(IBootstrapAssemblyMarker).Assembly;
    }

    #endregion
  }
}
