using System;
using CSF.Validation;

namespace Agiil.Domain.Validation
{
  public interface ICreatesValidators
  {
    IValidator GetValidator();
  }

  public interface ICreatesValidators<T> : ICreatesValidators where T : class
  {
  }
}
