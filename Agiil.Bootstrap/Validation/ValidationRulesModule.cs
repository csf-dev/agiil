using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Agiil.Domain;
using Agiil.Domain.Validation;
using Autofac;
using CSF.Validation;
using CSF.Validation.Rules;
using CSF.Validation.StockRules;

namespace Agiil.Bootstrap.Validation
{
  public class ValidationRulesModule : Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      RegisterStockRules(builder);
      RegisterGenericStockRules(builder);
      RegisterAgiilRules(builder);
      RegisteGenericAgiilRules(builder);
    }

    void RegisterAgiilRules(ContainerBuilder builder)
    {
      var ruleTypes = GetNamespaceRules<EndDateMustNotBeBeforeStartDateRule>();
      RegisterAllTypes(ruleTypes, builder);
    }

    void RegisterStockRules(ContainerBuilder builder)
    {
      var ruleTypes = GetNamespaceRules<NotNullRule>();
      RegisterAllTypes(ruleTypes, builder);
    }

    void RegisteGenericAgiilRules(ContainerBuilder builder)
    {
      builder.RegisterGeneric(typeof(EntityMustExistRule<>));
    }

    void RegisterGenericStockRules(ContainerBuilder builder)
    {
      builder.RegisterGeneric(typeof(IsDefinedEnumMemberValueRule<>));
      builder.RegisterGeneric(typeof(NullableIsDefinedEnumMemberValueRule<>));
    }

    IEnumerable<Type> GetNamespaceRules<TTypeInNamespace>()
    {
      var type = typeof(TTypeInNamespace);
      var assembly = type.Assembly;
      var ns = type.Namespace;
      return GetNamespaceRules(assembly, ns);
    }

    IEnumerable<Type> GetNamespaceRules(Assembly assembly, string ns)
    {
      return assembly
        .GetExportedTypes()
        .Where(type => type.IsClass
                       && !type.IsAbstract
                       && type.Namespace == ns
                       && !type.IsGenericTypeDefinition
                       && typeof(IRule).IsAssignableFrom(type))
        .ToArray();
    }

    void RegisterAllTypes(IEnumerable<Type> ruleTypes, ContainerBuilder builder)
    {
      foreach(var ruleType in ruleTypes)
      {
        builder.RegisterType(ruleType);
      }
    }
  }
}
