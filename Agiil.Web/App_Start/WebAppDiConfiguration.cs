using System;
using System.Reflection;
using System.Web.Http;
using Agiil.Bootstrap;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using NHibernate;

namespace Agiil.Web.App_Start
{
  public class WebAppDiConfiguration : DomainDiConfiguration
  {
    #region fields

    readonly HttpConfiguration config;
    readonly bool overrideScope;

    #endregion

    #region public API

    public override ContainerBuilder GetContainerBuilder()
    {
      var builder = base.GetContainerBuilder();

      RegisterWebAppComponents(builder);

      RegisterAspNetWebApiComponents(builder);

      RegisterAspNetMvcComponents(builder);

      RegsiterOverriddenScopeComponents(builder);

      return builder;
    }

    protected virtual void RegisterAspNetMvcComponents(ContainerBuilder builder)
    {
      var mvcAssembly = GetMvcAssembly();

      builder.RegisterControllers(mvcAssembly);
      builder.RegisterModelBinders(mvcAssembly);
      builder.RegisterModelBinderProvider();
      builder.RegisterModule<AutofacWebTypesModule>();
    }

    protected virtual void RegisterAspNetWebApiComponents(ContainerBuilder builder)
    {
      var apiAssembly = GetWebApiAssembly();

      builder.RegisterApiControllers(apiAssembly);
      builder.RegisterWebApiFilterProvider(config);
    }

    protected virtual void RegisterWebAppComponents(ContainerBuilder builder)
    {
      builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
    }

    protected virtual void RegsiterOverriddenScopeComponents(ContainerBuilder builder)
    {
      if(!overrideScope)
        return;

      // ISession
      builder
        .Register((ctx, parameters) => {
          var factory = ctx.Resolve<ISessionFactory>();
          return factory.OpenSession();
        })
        .InstancePerRequest();
    }

    protected virtual Assembly GetMvcAssembly()
    {
      return Assembly.GetExecutingAssembly();
    }

    protected virtual Assembly GetWebApiAssembly()
    {
      return Assembly.GetExecutingAssembly();
    }

    #endregion

    #region constructors

    public WebAppDiConfiguration(HttpConfiguration config = null, bool overrideScope = false)
    {
      this.config = config?? new HttpConfiguration();
      this.overrideScope = overrideScope;
    }

    #endregion
  }
}
