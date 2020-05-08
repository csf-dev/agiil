using System;
using System.Linq;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Domain.TicketSearch;
using CSF.Specifications;

namespace Agiil.Domain.TicketCriterionConvertionStrategies
{
  public class HasAllLabelsConversionStrategy : IStrategyForConvertingCriterionToSpecification
  {
    readonly IResolvesValue valueResolver;

    public ISpecificationExpression<Ticket> ConvertToSpecification(Criterion criterion)
    {
      var predicateFunction = criterion?.Test as PredicateFunction;
      if(predicateFunction == null) return null;
      var labelNames = valueResolver.ResolveAll<string>(predicateFunction.Parameters);
      var spec = new HasAllLabels(labelNames);

      if(predicateFunction.Inverted)
        return spec.Not();

      return spec;
    }

    public static CriterionToSpecificationConversionStrategyMetadata GetMetadata() => new HasAllLabelsConversionMetadata();

    CriterionToSpecificationConversionStrategyMetadata IStrategyForConvertingCriterionToSpecification.GetMetadata()
                                                                                                     => GetMetadata();

    public HasAllLabelsConversionStrategy(IResolvesValue valueResolver)
    {
      if(valueResolver == null)
        throw new ArgumentNullException(nameof(valueResolver));
      this.valueResolver = valueResolver;
    }

    class HasAllLabelsConversionMetadata : CriterionToSpecificationConversionStrategyMetadata
    {
      public override bool CanConvertAsPredicateFunction(string elementName,
                                                         string predicateFunctionName,
                                                         int parameterCount)
      {
        return (elementName == ElementName.Labels
                && predicateFunctionName == PredicateName.Function.HasAllOf
                && parameterCount > 0);
      }
    }
  }
}
