using System;
using System.Reflection;
using Agiil.Bootstrap;
using Autofac;

namespace Agiil.Tests.Common
{
  public class ApiOnlyContainerBuilderFactory : IAutofacContainerBuilderFactory
  {
    public virtual ContainerBuilder GetContainerBuilder()
    {
      var builder = CreateBuilder();

      RegisterApplicationApiModules(builder);
      RegisterTestControllerModules(builder);

      return builder;
    }

    protected virtual void RegisterApplicationApiModules(ContainerBuilder builder)
    {
      builder.RegisterAssemblyModules(Assembly.GetAssembly(typeof(IBootstrapAssemblyMarker)));
    }

    protected virtual void RegisterTestControllerModules(ContainerBuilder builder)
    {
      builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
    }

    protected virtual ContainerBuilder CreateBuilder()
    {
      return new ContainerBuilder();
    }
  }
}
