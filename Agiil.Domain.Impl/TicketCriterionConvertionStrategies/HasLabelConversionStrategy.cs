using System;
using System.Linq;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Domain.TicketSearch;
using CSF.Specifications;

namespace Agiil.Domain.TicketCriterionConvertionStrategies
{
  public class HasLabelConversionStrategy : IStrategyForConvertingCriterionToSpecification
  {
    readonly IResolvesValue valueResolver;

    public ISpecificationExpression<Ticket> ConvertToSpecification(Criterion criterion)
    {
      var metadata = GetMetadata();

      if(metadata.CanConvertAsPredicateWithValue(criterion))
        return GetFromPredicateAndValue(criterion);

      if(metadata.CanConvertAsPredicateFunction(criterion))
        return GetFromPredicateFunction(criterion);

      return null;
    }

    ISpecificationExpression<Ticket> GetFromPredicateAndValue(Criterion criterion)
    {
      var predicateAndValue = criterion.Test as PredicateAndValue;
      var labelName = valueResolver.Resolve<string>(predicateAndValue.Value);
      var spec = new HasLabel(labelName);

            if(predicateAndValue.PredicateText == PredicateName.NotEquals)
                return spec.Not();

      return spec;
    }

    ISpecificationExpression<Ticket> GetFromPredicateFunction(Criterion criterion)
    {
      var predicateFunction = criterion?.Test as PredicateFunction;
      if(predicateFunction == null) return null;
      var labelNames = valueResolver.ResolveAll<string>(predicateFunction.Parameters);
      var spec = new HasLabel(labelNames);

      if(predicateFunction.Inverted)
        return spec.Not();

      return spec;
    }

    public static CriterionToSpecificationConversionStrategyMetadata GetMetadata() => new HasLabelConversionMetadata();

    CriterionToSpecificationConversionStrategyMetadata IStrategyForConvertingCriterionToSpecification.GetMetadata()
      => GetMetadata();

    public HasLabelConversionStrategy(IResolvesValue valueResolver)
    {
      if(valueResolver == null)
        throw new ArgumentNullException(nameof(valueResolver));
      this.valueResolver = valueResolver;
    }

    class HasLabelConversionMetadata : CriterionToSpecificationConversionStrategyMetadata
    {
      public override bool CanConvertAsPredicateWithValue(string elementName, string predicateText)
			{
        return (elementName == ElementName.Label
                && (predicateText == PredicateName.Equals || predicateText == PredicateName.NotEquals));
			}

      public override bool CanConvertAsPredicateFunction(string elementName,
                                                         string predicateFunctionName,
                                                         int parameterCount)
			{
        return (elementName == ElementName.Labels
                && predicateFunctionName == PredicateName.Function.HasAnyOf
                && parameterCount > 0);
			}
		}
  }
}
