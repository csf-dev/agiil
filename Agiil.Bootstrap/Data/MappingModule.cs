using System;
using System.Collections.Generic;
using System.Reflection;
using Agiil.Data;
using Autofac;
using System.Linq;

namespace Agiil.Bootstrap.Data
{
  public class MappingModule : Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<SessionFactoryFactory>()
        .As<ISessionFactoryFactory>();
      
      builder
        .RegisterType<MappingProvider>()
        .As<IMappingProvider>();

      RegisterAllMappings(builder);

      builder
        .RegisterType<ConfigurationManagerConnectionStringProvider>()
        .As<IConnectionStringProvider>();

      builder
        .RegisterType<LowercaseWithUnderscoreDbNameFormatter>()
        .As<IDbNameFormatter>();
    }

    void RegisterAllMappings(ContainerBuilder builder)
    {
      var allMappingTypes = GetAllMappingTypes();
      builder.RegisterTypes(allMappingTypes).As<IMapping>();
    }

    Type[] GetAllMappingTypes()
    {

      return (from type in Assembly.GetAssembly(typeof(IDataAssemblyMarker)).GetExportedTypes()
              where
                type.IsClass
                && !type.IsAbstract
                && typeof(IMapping).IsAssignableFrom(type)
              select type)
        .ToArray();
    }
  }
}
