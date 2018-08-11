using System;
using CSF.Validation;

namespace Agiil.Domain.Validation
{
  public interface IGenericValidator
  {
    IValidationResult Validate<T>(T toValidate) where T : class;
  }
}
