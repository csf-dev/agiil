using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using CSF.Validation;
using CSF.Validation.Rules;
using Agiil.Domain;

namespace Agiil.Bootstrap.Validation
{
  public class ValidationModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<AutofacValidationRuleResolver>()
        .As<IRuleResolver>();

      builder
        .Register(CreateValidatorFactory)
        .As<IValidatorFactory>();

      builder
        .RegisterGeneric(typeof(ResponseFactory<>))
        .As(typeof(IResponseFactory<>));

      builder
        .RegisterType<AutofacGenericValidator>()
        .AsImplementedInterfaces();
    }

    ValidatorFactory CreateValidatorFactory(IComponentContext ctx, IEnumerable<Parameter> afParams)
    {
      return new ValidatorFactory(ctx.Resolve<IRuleResolver>(), null, null);
    }
  }
}
