using System;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public class CreateCommentResponse
  {
    readonly IValidationResult validationResult;
    readonly IValidationResultInterpreter resultInterpreter;

    public Comment Comment { get; private set; }

    public bool IsSuccess => validationResult.IsSuccess;

    public bool BodyIsInvalid 
    {
      get {
        return resultInterpreter.IncludesFailureFor<CreateCommentRequest>(validationResult, x => x.Body);
      }
    }

    public CreateCommentResponse(IValidationResult result,
                                 IValidationResultInterpreter resultInterpreter,
                                 Comment comment = null)
    {
      if(resultInterpreter == null)
        throw new ArgumentNullException(nameof(resultInterpreter));
      if(result == null)
        throw new ArgumentNullException(nameof(result));

      Comment = comment;
      this.validationResult = result;
      this.resultInterpreter = resultInterpreter;
    }
  }
}
