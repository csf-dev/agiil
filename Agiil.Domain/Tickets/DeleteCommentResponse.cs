using System;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public class DeleteCommentResponse : IIndictesSuccess
  {
    readonly IValidationResult validationResult;
    readonly IValidationResultInterpreter resultInterpreter;

    public bool IsSuccess => validationResult.IsSuccess;

    public DeleteCommentResponse(IValidationResult result,
                                 IValidationResultInterpreter resultInterpreter)
    {
      if(resultInterpreter == null)
        throw new ArgumentNullException(nameof(resultInterpreter));
      if(result == null)
        throw new ArgumentNullException(nameof(result));

      this.validationResult = result;
      this.resultInterpreter = resultInterpreter;
    }
  }
}
