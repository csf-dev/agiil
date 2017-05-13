using System;
using System.Linq.Expressions;
using CSF.Validation;
using CSF.Validation.ValidationRuns;

namespace Agiil.Domain
{
  public interface IValidationResultInterpreter
  {
    bool IsSuccess(IRunnableRuleResult result);

    bool IncludesFailureFor<TValidated>(IValidationResult result,
                                        Expression<Func<TValidated,object>> propertyExpression);
  }
}
