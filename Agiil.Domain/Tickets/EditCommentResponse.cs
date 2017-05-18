using System;
using System.Linq;
using Agiil.Domain.Validation;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public class EditCommentResponse : IIndictesSuccess
  {
    readonly IValidationResult validationResult;
    readonly IValidationResultInterpreter resultInterpreter;

    public bool IsSuccess => validationResult.IsSuccess;

    public bool UserDoesNotHavePermission
      => resultInterpreter.IncludesFailureFor<EditCommentRequest>(validationResult,
                                                                  name: RuleNames.Comments.EditingPermissionDenied);

    public bool BodyIsInvalid
      => resultInterpreter.IncludesFailureFor<EditCommentRequest>(validationResult, x => x.Body);

    public bool CommentDoesNotExist
      => resultInterpreter.IncludesFailureFor<EditCommentRequest>(validationResult,
                                                                  prop: x => x.CommentIdentity,
                                                                  name: RuleNames.EntityMustExist);

    public EditCommentResponse(IValidationResult result,
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
