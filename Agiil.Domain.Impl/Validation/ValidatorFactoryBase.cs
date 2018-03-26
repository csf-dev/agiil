using System;
using CSF.Validation;
using CSF.Validation.Manifest;
using CSF.Validation.Manifest.Fluent;

namespace Agiil.Domain.Validation
{
  public abstract class ValidatorFactoryBase<TValidated> : ICreatesValidators<TValidated>
    where TValidated : class
  {
    readonly IValidatorFactory validatorFactory;

    public virtual IValidator GetValidator()
    {
      var manifest = GetManifest();

      return validatorFactory.GetValidator(manifest);
    }

    protected virtual IValidationManifest GetManifest()
    {
      var builder = ManifestBuilder.Create<TValidated>();

      ConfigureManifest(builder);

      return builder.GetManifest();
    }

    protected abstract void ConfigureManifest(IManifestBuilder<TValidated> builder);

    public ValidatorFactoryBase(IValidatorFactory validatorFactory)
    {
      if(validatorFactory == null)
        throw new ArgumentNullException(nameof(validatorFactory));

      this.validatorFactory = validatorFactory;
    }
  }
}
