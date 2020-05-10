using System;
using System.Linq;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Domain.TicketSearch;
using CSF.Specifications;

namespace Agiil.Domain.TicketCriterionConvertionStrategies
{
  public class IsInSprintConversionStrategy : IStrategyForConvertingCriterionToSpecification
  {
    readonly IResolvesValue valueResolver;

    public ISpecificationExpression<Ticket> ConvertToSpecification(Criterion criterion)
    {
      var metadata = GetMetadata();

      if(metadata.CanConvertAsPredicateFunction(criterion))
        return GetFromPredicateFunction(criterion);

      if(metadata.CanConvertAsPredicateWithValue(criterion))
        return GetFromPredicateAndValue(criterion);

      return null;
    }

    ISpecificationExpression<Ticket> GetFromPredicateAndValue(Criterion criterion)
    {
      var predicateAndValue = criterion.Test as PredicateAndValue;
      var sprintName = valueResolver.Resolve<string>(predicateAndValue.Value);
      var spec = new HasSprint(sprintName);

      if(predicateAndValue.PredicateText == PredicateName.NotEquals)
        return spec.Not();

      return spec;
    }

    ISpecificationExpression<Ticket> GetFromPredicateFunction(Criterion criterion)
    {
      var predicateFunction = criterion?.Test as PredicateFunction;
      if(predicateFunction == null) return null;
      var sprintNames = valueResolver.ResolveAll<string>(predicateFunction.Parameters);
      var spec = new HasSprint(sprintNames);

      if(predicateFunction.Inverted)
        return spec.Not();

      return spec;
    }

    public static CriterionToSpecificationConversionStrategyMetadata GetMetadata() => new IsInSprintConversionMetadata();

    CriterionToSpecificationConversionStrategyMetadata IStrategyForConvertingCriterionToSpecification.GetMetadata()
                                                                                                     => GetMetadata();

    public IsInSprintConversionStrategy(IResolvesValue valueResolver)
    {
      if(valueResolver == null)
        throw new ArgumentNullException(nameof(valueResolver));
      this.valueResolver = valueResolver;
    }

    class IsInSprintConversionMetadata : CriterionToSpecificationConversionStrategyMetadata
    {
			public override bool CanConvertAsPredicateWithValue(string elementName, string predicateText)
			{
        return (elementName == ElementName.Sprint
                && (predicateText == PredicateName.Equals || predicateText == PredicateName.NotEquals));
			}

			public override bool CanConvertAsPredicateFunction(string elementName, string predicateFunctionName, int parameterCount)
			{
        return (elementName == ElementName.Sprint
                && predicateFunctionName == PredicateName.Function.IsAnyOf
                && parameterCount > 0);
			}
		}
  }
}
