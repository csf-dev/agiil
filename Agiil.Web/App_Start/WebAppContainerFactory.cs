using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using Agiil.Bootstrap;
using Autofac;
using System.Linq;
using Agiil.Web.Bootstrap;
using Autofac.Core;

namespace Agiil.Web.App_Start
{
  public class WebAppContainerFactory : DomainContainerFactory, IContainerFactoryWithHttpConfiguration
  {
    #region fields

    HttpConfiguration config;

    #endregion

    #region properties

    protected virtual HttpConfiguration HttpConfig => config;

    #endregion

    #region public API

    public override ContainerBuilder GetContainerBuilder()
    {
      var builder = base.GetContainerBuilder();

      RegisterWebAppComponents(builder);

      RegisterAspNetWebApiComponents(builder);

      RegisterAspNetMvcComponents(builder);

      return builder;
    }

    protected virtual void RegisterAspNetMvcComponents(ContainerBuilder builder)
    {
      builder.RegisterModule(new AspNetMvcModule());
    }

    protected virtual void RegisterAspNetWebApiComponents(ContainerBuilder builder)
    {
      builder.RegisterModule(new AspNetWebApiModule(HttpConfig));
    }

    protected virtual void RegisterWebAppComponents(ContainerBuilder builder)
    {
      var modulesToAutoRegister = GetAllAssemblyModules()
        .Except(GetModuleTypesNotToRegisterAutomatically())
        .ToArray();

      foreach(var moduleType in modulesToAutoRegister)
      {
        builder.RegisterModule((IModule) Activator.CreateInstance(moduleType));
      }
    }

    protected virtual IEnumerable<Type> GetModuleTypesNotToRegisterAutomatically()
    {
      return new [] {
        typeof(AspNetMvcModule),
        typeof(AspNetWebApiModule),
      };
    }

    protected virtual IEnumerable<Assembly> GetAssembliesToAutoscan()
    {
      return new [] { Assembly.GetExecutingAssembly() };
    }

    protected virtual IEnumerable<Type> GetAllAssemblyModules()
    {
      var moduleType = typeof(Autofac.Module);
      var assembliesToScan = GetAssembliesToAutoscan();

      return (from assembly in assembliesToScan
              from type in assembly.GetExportedTypes()
              where
                moduleType.IsAssignableFrom(type)
                && type.IsClass
                && !type.IsAbstract
              select type)
        .ToArray();
    }

    public virtual void SetHttpConfiguration(HttpConfiguration config)
    {
      if(config == null)
        throw new ArgumentNullException(nameof(config));
      
      this.config = config;
    }

    #endregion

    #region constructors

    public WebAppContainerFactory()
    {
      config = new HttpConfiguration();
    }

    #endregion
  }
}
