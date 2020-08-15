using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Domain.TicketSearch;
using CSF.Specifications;

namespace Agiil.Domain.TicketCriterionConvertionStrategies
{
    public class TicketTypeEqualsConversionStrategy : IStrategyForConvertingCriterionToSpecification
    {
        readonly IResolvesValue valueResolver;

        public ISpecificationExpression<Ticket> ConvertToSpecification(Criterion criterion)
        {
            var predicate = criterion?.Test as PredicateAndValue;
            if(predicate == null) return null;
            var typeName = valueResolver.Resolve<string>(predicate.Value);
            var spec = new TicketTypeNameEquals(typeName);

            if(predicate.PredicateText == PredicateName.NotEquals)
                return spec.Not();

            return spec;
        }

        public static CriterionToSpecificationConversionStrategyMetadata GetMetadata() => new TicketTypeEqualsConversionMetadata();

        CriterionToSpecificationConversionStrategyMetadata IStrategyForConvertingCriterionToSpecification.GetMetadata()
                                                                                                         => GetMetadata();

        public TicketTypeEqualsConversionStrategy(IResolvesValue valueResolver)
        {
            this.valueResolver = valueResolver ?? throw new ArgumentNullException(nameof(valueResolver));
        }

        class TicketTypeEqualsConversionMetadata : CriterionToSpecificationConversionStrategyMetadata
        {
            public override bool CanConvertAsPredicateWithValue(string elementName, string predicateText)
            {
                return elementName == ElementName.TicketType
                    && (predicateText == PredicateName.Equals || predicateText == PredicateName.NotEquals);
            }
        }
    }
}
