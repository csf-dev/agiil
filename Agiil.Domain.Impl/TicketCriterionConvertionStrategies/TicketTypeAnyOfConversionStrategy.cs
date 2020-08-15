using System;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Domain.TicketSearch;
using CSF.Specifications;

namespace Agiil.Domain.TicketCriterionConvertionStrategies
{
    public class TicketTypeAnyOfConversionStrategy : IStrategyForConvertingCriterionToSpecification
    {
        readonly IResolvesValue valueResolver;

        public ISpecificationExpression<Ticket> ConvertToSpecification(Criterion criterion)
        {
            var predicateFunction = criterion?.Test as PredicateFunction;
            if(predicateFunction == null) return null;
            var typeNames = valueResolver.ResolveAll<string>(predicateFunction.Parameters);
            var spec = new TicketTypeNameIsAnyOf(typeNames);

            if(predicateFunction.Inverted)
                return spec.Not();

            return spec;
        }

        public static CriterionToSpecificationConversionStrategyMetadata GetMetadata() => new TicketTypeAnyOfConversionMetadata();

        CriterionToSpecificationConversionStrategyMetadata IStrategyForConvertingCriterionToSpecification.GetMetadata()
                                                                                                         => GetMetadata();

        public TicketTypeAnyOfConversionStrategy(IResolvesValue valueResolver)
        {
            this.valueResolver = valueResolver ?? throw new ArgumentNullException(nameof(valueResolver));
        }

        class TicketTypeAnyOfConversionMetadata : CriterionToSpecificationConversionStrategyMetadata
        {
            public override bool CanConvertAsPredicateFunction(string elementName, string predicateFunctionName, int parameterCount)
            {
                return (elementName == ElementName.TicketType
                        && predicateFunctionName == PredicateName.Function.IsAnyOf
                        && parameterCount > 0);
            }
        }
    }
}
