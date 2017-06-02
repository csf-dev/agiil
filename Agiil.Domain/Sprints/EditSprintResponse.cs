using System;
using Agiil.Domain.Validation;
using CSF.Validation;

namespace Agiil.Domain.Sprints
{
  public class EditSprintResponse : IIndictesSuccess
  {
    readonly IValidationResult validationResult;
    readonly IValidationResultInterpreter resultInterpreter;

    public Sprint Sprint { get; set; }

    public bool IdIsInvalid
      => resultInterpreter.IncludesFailureFor<EditSprintRequest>(validationResult, x => x.SprintIdentity);

    public bool NameIsInvalid
      => resultInterpreter.IncludesFailureFor<EditSprintRequest>(validationResult, x => x.Name);

    public bool EndDateMustNotBeBeforeStartDate
      => resultInterpreter.IncludesFailureFor<EditSprintRequest>(validationResult,
                                                                         name: RuleNames.EndDateBeforeStartDate);

    public bool IsSuccess
      => !(IdIsInvalid || NameIsInvalid || EndDateMustNotBeBeforeStartDate);

    public EditSprintResponse(IValidationResult result,
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
