using System;
using CSF.Validation;

namespace Agiil.Domain.Validation
{
  public interface IValidatorFactory<T> where T : class
  {
    IValidator GetValidator();
  }
}
