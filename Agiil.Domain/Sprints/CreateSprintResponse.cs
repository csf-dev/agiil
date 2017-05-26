using System;
using Agiil.Domain.Validation;
using CSF.Validation;

namespace Agiil.Domain.Sprints
{
  public class CreateSprintResponse : IIndictesSuccess
  {
    readonly IValidationResult validationResult;
    readonly IValidationResultInterpreter resultInterpreter;

    public Sprint Sprint { get; set; }

    public bool ProjectDoesNotExist { get; set; }

    public bool NameIsInvalid
    {
      get {
        return resultInterpreter.IncludesFailureFor<CreateSprintRequest>(validationResult, x => x.Name);
      }
    }

    public bool EndDateMustNotBeBeforeStartDate
    {
      get {
        return resultInterpreter.IncludesFailureFor<CreateSprintRequest>(validationResult,
                                                                         name: RuleNames.EndDateBeforeStartDate);
      }
    }

    public bool IsSuccess
      => !(ProjectDoesNotExist || NameIsInvalid || EndDateMustNotBeBeforeStartDate);

    public CreateSprintResponse(IValidationResult result,
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
