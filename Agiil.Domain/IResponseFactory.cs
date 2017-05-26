using System;
using CSF.Validation;

namespace Agiil.Domain
{
  public interface IResponseFactory<TResponse>
  {
    TResponse GetResponse(IValidationResult result);
  }
}
