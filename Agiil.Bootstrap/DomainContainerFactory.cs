using System.Collections.Generic;
using System.Reflection;
using Agiil.Bootstrap.ObjectMaps;
using Agiil.ObjectMaps;
using Autofac;

namespace Agiil.Bootstrap
{
  public class DomainContainerFactory : IGetsAutofacContainer
  {
    public virtual IContainer GetContainer()
    {
      var builder = GetContainerBuilder();
      return builder.Build();
    }

    public virtual ContainerBuilder GetContainerBuilder()
    {
      var builder = CreateContainerBuilder();

      RegisterDomainComponents(builder);

      return builder;
    }

    protected virtual void RegisterDomainComponents(ContainerBuilder builder)
    {
      var scannedAssemblies = GetModuleAssemblies();

      new OrderedModuleBulkRegistrationService(scannedAssemblies).RegisterModules(builder);
      new UnorderedModuleBulkRegistrationService(scannedAssemblies).RegisterModules(builder);

      RegisterAllAutomapperProfiles(builder);
    }

    protected virtual void RegisterAllAutomapperProfiles(ContainerBuilder builder)
    {
      var provider = GetProfileTypesProvider();
      var module = new AutomapperProfilesModule(provider);
      builder.RegisterModule(module);
    }

    protected virtual IEnumerable<Assembly> GetModuleAssemblies()
    {
      return new [] {
        Assembly.GetExecutingAssembly(),
      };
    }

    protected virtual IProfileTypesProvider GetProfileTypesProvider()
    {
      return new ProfileTypesProvider();
    }

    protected virtual ContainerBuilder CreateContainerBuilder()
    {
      return new ContainerBuilder();
    }
  }
}
