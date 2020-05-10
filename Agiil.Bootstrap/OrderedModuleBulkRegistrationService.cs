using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Agiil.Bootstrap.Specifications;
using Autofac;
using CSF.Specifications;

namespace Agiil.Bootstrap
{
  public class OrderedModuleBulkRegistrationService : IRegistersModulesInBulk
  {
    readonly IEnumerable<Assembly> moduleAssemblies;

    public void RegisterModules(ContainerBuilder builder)
    {
      var pass = 1;
      IEnumerable<Autofac.Module> modulesToRegister;

      while((modulesToRegister = GetOrderedModules(pass++)) != null && modulesToRegister.Any())
      {
        foreach(var module in modulesToRegister)
          builder.RegisterModule(module);
      }
    }

    IEnumerable<Autofac.Module> GetOrderedModules(int pass)
    {
      var spec = GetOrderedModuleSpecification();

      var orderedModuleTypes = moduleAssemblies.SelectMany(x => x.GetExportedTypes()).Where(spec);

      return (from moduleType in orderedModuleTypes
              let orderAttribute = moduleType.GetCustomAttribute<RegistrationOrderAttribute>()
              where orderAttribute.RegistrationPass == pass
              select Activator.CreateInstance(moduleType))
        .Cast<Autofac.Module>()
        .ToArray();

    }

    ISpecificationExpression<Type> GetOrderedModuleSpecification()
    {
      return new IsConcreteSpecification()
        .And(new ImplementsSpecification<Autofac.Module>())
        .And(new HasAttributeSpecification<RegistrationOrderAttribute>())
        .And(new HasParameterlessConstructorSpecification())
        .And(new HasAttributeSpecification<DoNotAutoRegisterAttribute>().Not());
    }

    public OrderedModuleBulkRegistrationService(IEnumerable<Assembly> moduleAssemblies)
    {
      if(moduleAssemblies == null)
        throw new ArgumentNullException(nameof(moduleAssemblies));
      this.moduleAssemblies = moduleAssemblies;
    }
  }
}
