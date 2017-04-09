using System;
using System.Reflection;
using Agiil.Auth;
using Agiil.Bootstrap;
using Agiil.Web.App_Start;
using Autofac;

namespace Agiil.Tests.Common
{
  public class WebAppTestDiConfiguration : WebAppDiConfiguration
  {
    public override ContainerBuilder GetContainerBuilder()
    {
      var builder = base.GetContainerBuilder();

      OverrideUnwantedWebComponents(builder);

      RegisterTestComponents(builder);

      return builder;
    }

    protected virtual void RegisterTestComponents(ContainerBuilder builder)
    {
      UnitTestDiConfiguration.RegisterTestComponentModules(builder);
    }

    protected virtual void OverrideUnwantedWebComponents(ContainerBuilder builder)
    {
      builder.RegisterType<CurrentThreadPrincipalGetter>().As<IPrincipalGetter>();
    }
  }
}
