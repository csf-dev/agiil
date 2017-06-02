using System;
using System.Reflection;
using Agiil.Bootstrap;
using Agiil.Tests.ObjectMaps;
using Autofac;

namespace Agiil.Tests
{
  public class UnitTestDiConfiguration : DomainDiConfiguration
  {
    public override ContainerBuilder GetContainerBuilder()
    {
      var builder = base.GetContainerBuilder();

      RegisterTestComponents(builder);

      return builder;
    }

    protected virtual void RegisterTestComponents(ContainerBuilder builder)
    {
      RegisterTestComponentModules(builder);
    }

    protected override Agiil.ObjectMaps.IProfileTypesProvider GetProfileTypesProvider()
    {
      return new TestingProfileTypesProvider();
    }

    internal static void RegisterTestComponentModules(ContainerBuilder builder)
    {
      builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
    }
  }
}
