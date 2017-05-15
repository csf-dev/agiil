using System;
using System.Linq;
using System.Linq.Expressions;
using CSF.Reflection;
using CSF.Validation;
using CSF.Validation.Manifest;
using CSF.Validation.Rules;
using CSF.Validation.ValidationRuns;

namespace Agiil.Domain
{
  public class ValidationResultInterpreter : IValidationResultInterpreter
  {
    internal static readonly RuleOutcome[] SuccessOutcomes = {
      RuleOutcome.Success,
      RuleOutcome.IntentionallySkipped,
    };

    public bool IsSuccess(IRunnableRuleResult result)
    {
      if(result == null)
        throw new ArgumentNullException(nameof(result));

      return SuccessOutcomes.Contains(result.RuleResult.Outcome);
    }

    public bool IncludesFailureFor<TValidated>(IValidationResult result,
                                               Expression<Func<TValidated,object>> propertyExpression)
    {
      if(propertyExpression == null)
        throw new ArgumentNullException(nameof(propertyExpression));
      if(result == null)
        throw new ArgumentNullException(nameof(result));

      if(result.IsSuccess)
        return false;

      var property = Reflect.Property(propertyExpression);

      return result
        .RuleResults
        .Where(x => !IsSuccess(x))
        .Select(x => x.ManifestIdentity)
        .Cast<DefaultManifestIdentity>()
        .Any(x => x.ValidatedMember == property);
    }
  }
}
