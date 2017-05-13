using System;
using System.Collections.Generic;
using System.Reflection;
using Agiil.Domain;
using Autofac;
using System.Linq;

namespace Agiil.Bootstrap
{
  public abstract class NamespaceModule : Autofac.Module
  {
    protected abstract string Namespace { get; }

    protected virtual IEnumerable<Assembly> GetSearchAssemblies()
    {
      return new [] {
        Assembly.GetAssembly(typeof(IDomainAssemblyMarker)),
        Assembly.GetAssembly(typeof(IDomainImplementationAssemblyMarker))
      };
    }

    protected virtual IEnumerable<Type> GetServiceImplementationTypes(IEnumerable<Assembly> searchAssemblies)
    {
      return searchAssemblies
        .SelectMany(x => x.GetExportedTypes())
        .Where(ServiceImplementationTypeFilter)
        .ToArray();
    }

    protected virtual bool ServiceImplementationTypeFilter(Type type)
    {
      return (type.IsClass
              && !type.IsAbstract
              && !type.IsGenericTypeDefinition
              && type.Namespace == Namespace);
    }

    protected override void Load(ContainerBuilder builder)
    {
      var searchAssemblies = GetSearchAssemblies();
      var typesToRegister = GetServiceImplementationTypes(searchAssemblies);

      foreach(var type in typesToRegister)
      {
        builder.RegisterType(type).AsSelf().AsImplementedInterfaces();
      }
    }
  }
}
