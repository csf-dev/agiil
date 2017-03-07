using System;
using System.Reflection;
using Agiil.Bootstrap;
using Agiil.Web.App_Start;
using Autofac;

namespace Agiil.Tests.Common
{
  public class WebControllerContainerBuilderFactory : ApiOnlyContainerBuilderFactory
  {
    public override ContainerBuilder GetContainerBuilder()
    {
      var builder = CreateBuilder();

      RegisterApplicationApiModules(builder);
      RegisterAspNetModules(builder);
      RegisterTestControllerModules(builder);

      return builder;
    }

    protected virtual void RegisterAspNetModules(ContainerBuilder builder)
    {
      DependencyInjectionConfig.RegisterAspNetMvcComponents(builder);
      DependencyInjectionConfig.RegisterAspNetWebApiComponents(builder);
    }
 }
}
