using System;
using System.Collections.Generic;
using System.Reflection;
using Agiil.Domain.Validation;
using Autofac;
using Autofac.Core;
using CSF.Validation;
using CSF.Validation.Rules;
using System.Linq;
using CSF.Validation.StockRules;

namespace Agiil.Bootstrap.Validation
{
  public class ValidationModule : Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<AutofacValidationRuleResolver>()
        .As<IRuleResolver>();

      builder
        .Register(CreateValidatorFactory)
        .As<IValidatorFactory>();
    }

    ValidatorFactory CreateValidatorFactory(IComponentContext ctx, IEnumerable<Parameter> afParams)
    {
      return new ValidatorFactory(ctx.Resolve<IRuleResolver>(), null, null);
    }
  }
}
