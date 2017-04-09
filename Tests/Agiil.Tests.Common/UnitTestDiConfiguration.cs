using System;
using System.Reflection;
using Agiil.Bootstrap;
using Autofac;

namespace Agiil.Tests.Common
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

    internal static void RegisterTestComponentModules(ContainerBuilder builder)
    {
      builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
    }
  }
}
