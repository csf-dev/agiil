using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Domain.TicketSearch;
using CSF.Data.Specifications;

namespace Agiil.Domain.TicketCriterionConvertionStrategies
{
  public class HasNoSprintConversionStrategy : IStrategyForConvertingCriterionToSpecification
  {
    public ISpecificationExpression<Ticket> ConvertToSpecification(Criterion criterion)
    {
      var predicateFunction = criterion?.Test as PredicateFunction;
      if(predicateFunction == null) return null;
      var spec = new HasNoSprint();

      if(predicateFunction.Inverted)
        return spec.Negate();

      return spec;
    }

    public static CriterionToSpecificationConversionStrategyMetadata GetMetadata() => new HasNoSprintConversionMetadata();

    CriterionToSpecificationConversionStrategyMetadata IStrategyForConvertingCriterionToSpecification.GetMetadata()
                                                                                                     => GetMetadata();

    class HasNoSprintConversionMetadata : CriterionToSpecificationConversionStrategyMetadata
    {
      public override bool CanConvertAsPredicateFunction(string elementName, string predicateFunctionName, int parameterCount)
      {
        return (elementName == ElementName.Sprint
                && predicateFunctionName == PredicateName.Function.IsEmpty
                && parameterCount == 0);
      }
    }
  }
}
