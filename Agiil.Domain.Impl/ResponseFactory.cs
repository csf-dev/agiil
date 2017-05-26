using System;
using CSF.Validation;

namespace Agiil.Domain
{
  public class ResponseFactory<TResponse> : IResponseFactory<TResponse>
  {
    readonly Func<IValidationResult, TResponse> responseCreator;

    public TResponse GetResponse(IValidationResult result)
    {
      if(result == null)
        throw new ArgumentNullException(nameof(result));

      return responseCreator(result);
    }

    public ResponseFactory(Func<IValidationResult,TResponse> responseCreator)
    {
      if(responseCreator == null)
        throw new ArgumentNullException(nameof(responseCreator));
      this.responseCreator = responseCreator;
    }
  }
}
