using System;
using System.Collections.Generic;
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

    [Obsolete("The version with optional parameters should be used instead.")]
    public bool IncludesFailureFor<TValidated>(IValidationResult result,
                                               Expression<Func<TValidated,object>> propertyExpression)
    {
      return IncludesFailureFor(result, propertyExpression, null, null);
    }

    public bool IncludesFailureFor<TValidated>(IValidationResult result,
                                               Expression<Func<TValidated,object>> propertyExpression,
                                               Type ruleType,
                                               string name)
    {
      if(ReferenceEquals(result, null))
        throw new ArgumentNullException(nameof(result));
      if(result.IsSuccess)
        return false;

      var query = result
        .RuleResults
        .Where(x => !IsSuccess(x))
        .Select(x => x.ManifestIdentity)
        .Cast<DefaultManifestIdentity>();

      query = RefineQueryWithProperty(query, propertyExpression);
      query = RefineQueryWithRuleType(query, ruleType);
      query = RefineQueryWithRuleName(query, name);

      return query.Any();
    }

    IEnumerable<DefaultManifestIdentity> RefineQueryWithProperty<TValidated>(IEnumerable<DefaultManifestIdentity> query,
                                                                             Expression<Func<TValidated,object>> propertyExpression)
    {
      if(ReferenceEquals(propertyExpression,null))
        return query;

      return query.Where(x => x.ValidatedMember == Reflect.Property(propertyExpression));
    }

    IEnumerable<DefaultManifestIdentity> RefineQueryWithRuleType(IEnumerable<DefaultManifestIdentity> query,
                                                                 Type ruleType)
    {
      if(ReferenceEquals(ruleType,null))
        return query;

      return query.Where(x => x.RuleType == ruleType);
    }

    IEnumerable<DefaultManifestIdentity> RefineQueryWithRuleName(IEnumerable<DefaultManifestIdentity> query,
                                                                 string name)
    {
      if(ReferenceEquals(name,null))
        return query;

      return query.Where(x => x.Name == name);
    }
  }
}
