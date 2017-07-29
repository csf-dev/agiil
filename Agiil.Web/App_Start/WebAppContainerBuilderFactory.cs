using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;
using Agiil.Bootstrap;
using Agiil.Web.ModelBinders;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using NHibernate;

namespace Agiil.Web.App_Start
{
  public class WebAppContainerBuilderFactory : DomainContainerBuilderFactory, IWebAppContainerBuilderFactory
  {
    #region fields

    HttpConfiguration config;

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
      builder
        .RegisterType<AutofacMvcModelBinderProviderWithOpenGenericSupport>()
        .As<IModelBinderProvider>()
        .SingleInstance();
      builder.RegisterModule<AutofacWebTypesModule>();
    }

    protected virtual void RegisterAspNetWebApiComponents(ContainerBuilder builder)
    {
      var apiAssembly = GetWebApiAssembly();

      builder.RegisterApiControllers(apiAssembly);
      builder.RegisterWebApiFilterProvider(config);
      builder
        .RegisterType<AutofacWebApiModelBinderProviderWithOpenGenericSupport>()
        .As<ModelBinderProvider>();
    }

    protected virtual void RegisterWebAppComponents(ContainerBuilder builder)
    {
      builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
    }

    protected virtual void RegsiterOverriddenScopeComponents(ContainerBuilder builder)
    {
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

    public virtual void SetHttpConfiguration(HttpConfiguration config)
    {
      if(config == null)
        throw new ArgumentNullException(nameof(config));
      
      this.config = config;
    }

    #endregion

    #region constructors

    public WebAppContainerBuilderFactory()
    {
      config = new HttpConfiguration();
    }

    #endregion
  }
}
