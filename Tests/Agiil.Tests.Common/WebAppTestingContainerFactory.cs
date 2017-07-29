using System;
using System.Reflection;
using Agiil.Auth;
using Agiil.Bootstrap;
using Agiil.Tests.ObjectMaps;
using Agiil.Web.App_Start;
using Autofac;

namespace Agiil.Tests
{
  public class WebAppTestingContainerFactory : WebAppContainerFactory
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
      UnitTestContainerFactory.RegisterTestComponentModules(builder);
    }

    protected override Agiil.ObjectMaps.IProfileTypesProvider GetProfileTypesProvider()
    {
      return new TestingProfileTypesProvider();
    }

    protected virtual void OverrideUnwantedWebComponents(ContainerBuilder builder)
    {
      builder.RegisterType<CurrentThreadPrincipalGetter>().As<IPrincipalGetter>();
    }
  }
}
