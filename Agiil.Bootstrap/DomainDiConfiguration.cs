using System;
using System.Reflection;
using Autofac;

namespace Agiil.Bootstrap
{
  public class DomainDiConfiguration : IDiConfiguration
  {
    public virtual ContainerBuilder GetContainerBuilder()
    {
      var builder = CreateContainerBuilder();

      RegisterDomainComponents(builder);

      return builder;
    }

    protected virtual void RegisterDomainComponents(ContainerBuilder builder)
    {
      builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
    }

    protected virtual ContainerBuilder CreateContainerBuilder()
    {
      return new ContainerBuilder();
    }
  }
}
