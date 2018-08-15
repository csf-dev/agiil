using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Agiil.Bootstrap.Specifications;
using Autofac;
using CSF.Data.Specifications;

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
        .Select(x => Activator.CreateInstance(x))
        .Cast<Autofac.Module>()
        .ToArray();
    }

    ISpecification<Type> GetUnorderedModuleSpecification()
    {
      return new IsConcreteSpecification()
        .And(new ImplementsSpecification<Autofac.Module>())
        .And(new HasAttributeSpecification<RegistrationOrderAttribute>().Negate())
        .And(new HasParameterlessConstructorSpecification())
        .And(new HasAttributeSpecification<DoNotAutoRegisterAttribute>().Negate());
    }

    public UnorderedModuleBulkRegistrationService(IEnumerable<Assembly> moduleAssemblies)
    {
      if(moduleAssemblies == null)
        throw new ArgumentNullException(nameof(moduleAssemblies));
      this.moduleAssemblies = moduleAssemblies;
    }
  }
}
