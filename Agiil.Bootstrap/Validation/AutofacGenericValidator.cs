using System;
using Agiil.Domain.Validation;
using Autofac;
using CSF.Validation;

namespace Agiil.Bootstrap.Validation
{
  public class AutofacGenericValidator : IGenericValidator
  {
    readonly ILifetimeScope scope;

    public IValidationResult Validate<T>(T toValidate) where T : class
    {
      var validatorFactory = GetValidatorFactory<T>();
      var validator = validatorFactory.GetValidator();
      return validator.Validate(toValidate);
    }

    ICreatesValidators<T> GetValidatorFactory<T>() where T : class
    {
      ICreatesValidators<T> validatorFactory = null;
      if(scope.TryResolve(out validatorFactory))
        return validatorFactory;

      throw new MissingValidatorFactoryException($"There must be a generic implementation of {nameof(ICreatesValidators)} registered for type {typeof(T).FullName}.");
    }

    public AutofacGenericValidator(ILifetimeScope scope)
    {
      if(scope == null)
        throw new ArgumentNullException(nameof(scope));
      this.scope = scope;
    }
  }
}
