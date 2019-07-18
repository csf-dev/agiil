using System;
using System.Collections.Generic;
using System.Reflection;
using Agiil.Bootstrap.ObjectMaps;
using Agiil.ObjectMaps;
using Autofac;
using log4net;

namespace Agiil.Bootstrap
{
  public class DomainContainerFactory : IGetsAutofacContainer
  {
    static readonly ILog logger;

    public virtual IContainer GetContainer()
    {
      try
      {
        var builder = GetContainerBuilder();
        return builder.Build();
      }
      catch(Exception e)
      {
        logger.Error(e);
        throw;
      }
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

    static DomainContainerFactory()
    {
      logger = LogManager.GetLogger(typeof(DomainContainerFactory));
    }
  }
}
