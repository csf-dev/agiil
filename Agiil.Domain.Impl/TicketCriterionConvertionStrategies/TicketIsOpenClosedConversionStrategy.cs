using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Domain.TicketSearch;
using CSF.Specifications;

namespace Agiil.Domain.TicketCriterionConvertionStrategies
{
  public class TicketIsOpenClosedConversionStrategy : IStrategyForConvertingCriterionToSpecification
  {
    readonly IResolvesValue valueResolver;

    public ISpecificationExpression<Ticket> ConvertToSpecification(Criterion criterion)
    {
      var predicateAndValue = criterion?.Test as PredicateAndValue;
      if(predicateAndValue == null) return null;
      var value = valueResolver.Resolve<string>(predicateAndValue.Value);

      if(value == WellKnownValue.Closed)
        return new IsClosed();

      return new IsOpen();
    }

    public static CriterionToSpecificationConversionStrategyMetadata GetMetadata() => new TicketIsOpenClosedConversionMetadata();

    CriterionToSpecificationConversionStrategyMetadata IStrategyForConvertingCriterionToSpecification.GetMetadata()
                                                                                                     => GetMetadata();

    public TicketIsOpenClosedConversionStrategy(IResolvesValue valueResolver)
    {
      if(valueResolver == null)
        throw new ArgumentNullException(nameof(valueResolver));
      this.valueResolver = valueResolver;
    }

    class TicketIsOpenClosedConversionMetadata : CriterionToSpecificationConversionStrategyMetadata
    {
			public override bool CanConvertAsPredicateWithValue(string elementName, string predicateText)
			{
        return (elementName == ElementName.Ticket
                && predicateText == PredicateName.Is);
			}
    }
  }
}
