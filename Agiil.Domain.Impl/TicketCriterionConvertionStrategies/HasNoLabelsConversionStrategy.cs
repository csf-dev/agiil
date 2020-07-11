using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Domain.TicketSearch;
using CSF.Specifications;

namespace Agiil.Domain.TicketCriterionConvertionStrategies
{
  public class HasNoLabelsConversionStrategy : IStrategyForConvertingCriterionToSpecification
  {
    public ISpecificationExpression<Ticket> ConvertToSpecification(Criterion criterion)
    {
      var predicateFunction = criterion?.Test as PredicateFunction;
      if(predicateFunction == null) return null;
      var spec = new HasNoLabels();

      if(predicateFunction.Inverted)
        return spec.Not();

      return spec;
    }

    public static CriterionToSpecificationConversionStrategyMetadata GetMetadata() => new HasNoLabelsConversionMetadata();

    CriterionToSpecificationConversionStrategyMetadata IStrategyForConvertingCriterionToSpecification.GetMetadata()
                                                                                                     => GetMetadata();

    class HasNoLabelsConversionMetadata : CriterionToSpecificationConversionStrategyMetadata
    {
      public override bool CanConvertAsPredicateFunction(string elementName,
                                                         string predicateFunctionName,
                                                         int parameterCount)
      {
        return (elementName == ElementName.Labels
                && predicateFunctionName == PredicateName.Function.IsEmpty
                && parameterCount == 0);
      }
    }
  }
}
