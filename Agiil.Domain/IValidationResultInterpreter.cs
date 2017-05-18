using System;
using System.Linq.Expressions;
using CSF.Validation;
using CSF.Validation.ValidationRuns;

namespace Agiil.Domain
{
  public interface IValidationResultInterpreter
  {
    bool IsSuccess(IRunnableRuleResult result);

    [Obsolete("The version with optional parameters should be used instead.")]
    bool IncludesFailureFor<TValidated>(IValidationResult result,
                                        Expression<Func<TValidated,object>> prop);

    bool IncludesFailureFor<TValidated>(IValidationResult result,
                                        Expression<Func<TValidated,object>> prop = null,
                                        Type ruleType = null,
                                        string name = null);
  }
}
