using System;
using System.Linq;
using System.Reflection;
using Agiil.Domain.Validation;
using Autofac;
using CSF.Validation;
using CSF.Validation.StockRules;

namespace Agiil.Bootstrap.Validation
{
  public class ValidationRulesModule : Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      RegisterStockRules(builder);
      RegisterOurRules(builder);
    }

    void RegisterOurRules(ContainerBuilder builder)
    {
      builder.RegisterGeneric(typeof(EntityMustExistRule<>));
      builder.RegisterType<MustBeLoggedInAsCommentAuthorRule>();
    }

    void RegisterStockRules(ContainerBuilder builder)
    {
      var stockRuleTypes = (from type in Assembly.GetAssembly(typeof(IValidator)).GetExportedTypes()
                            where
                            type.IsClass
                            && !type.IsAbstract
                            && type.Namespace == typeof(NotNullRule).Namespace
                            && !type.IsGenericTypeDefinition
                            select type)
        .ToArray();

      foreach(var ruleType in stockRuleTypes)
      {
        builder.RegisterType(ruleType);
      }

      builder.RegisterGeneric(typeof(IsDefinedEnumMemberValueRule<>));
      builder.RegisterGeneric(typeof(NullableIsDefinedEnumMemberValueRule<>));
    }
  }
}
