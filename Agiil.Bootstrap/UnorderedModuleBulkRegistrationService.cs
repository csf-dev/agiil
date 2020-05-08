using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Agiil.Bootstrap.Specifications;
using Autofac;
using CSF.Specifications;

namespace Agiil.Bootstrap
{
  public class UnorderedModuleBulkRegistrationService : IRegistersModulesInBulk
  {
    readonly IEnumerable<Assembly> moduleAssemblies;

    public void RegisterModules(ContainerBuilder builder)
    {
      var modulesToRegister = GetUnorderedModules();
      if(modulesToRegister == null || !modulesToRegister.Any()) return;

      foreach(var module in modulesToRegister)
        builder.RegisterModule(module);
    }

    IEnumerable<Autofac.Module> GetUnorderedModules()
    {
      var spec = GetUnorderedModuleSpecification();

      var unorderedModuleTypes = moduleAssemblies.SelectMany(x => x.GetExportedTypes()).Where(spec);

      return unorderedModuleTypes
        .Select(Activator.CreateInstance)
        .Cast<Autofac.Module>()
        .ToArray();
    }

    ISpecificationExpression<Type> GetUnorderedModuleSpecification()
    {
      return new IsConcreteSpecification()
        .And(new ImplementsSpecification<Autofac.Module>())
        .And(new HasAttributeSpecification<RegistrationOrderAttribute>().Not())
        .And(new HasParameterlessConstructorSpecification())
        .And(new HasAttributeSpecification<DoNotAutoRegisterAttribute>().Not());
    }

    public UnorderedModuleBulkRegistrationService(IEnumerable<Assembly> moduleAssemblies)
    {
      if(moduleAssemblies == null)
        throw new ArgumentNullException(nameof(moduleAssemblies));
      this.moduleAssemblies = moduleAssemblies;
    }
  }
}
