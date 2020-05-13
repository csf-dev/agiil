using System;
using System.Linq;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Domain.TicketSearch;
using CSF.Specifications;

namespace Agiil.Domain.TicketCriterionConvertionStrategies
{
    public class StoryPointsConversionStrategy : IStrategyForConvertingCriterionToSpecification
    {
        readonly IResolvesValue valueResolver;
        readonly IGetsStoryPointsComparisonSpec comparisonSpecFactory;

        public ISpecificationExpression<Ticket> ConvertToSpecification(Criterion criterion)
        {
            var metadata = GetMetadata();

            if(metadata.CanConvertAsPredicateFunction(criterion))
                return GetSpecFromFunction((PredicateFunction) criterion.Test);

            if(metadata.CanConvertAsPredicateWithValue(criterion))
                return GetSpecFromPredicateAndValue((PredicateAndValue) criterion.Test);

            return null;
        }

        ISpecificationExpression<Ticket> GetSpecFromFunction(PredicateFunction function)
        {
            ISpecificationExpression<Ticket> spec = null;

            if(function.FunctionName == PredicateName.Function.IsEmpty)
                spec = new HasNoStoryPoints();

            if(function.FunctionName == PredicateName.Function.IsAnyOf)
                spec = new StoryPointsIsOneOf(valueResolver.ResolveAll<int>(function.Parameters));

            if(spec != null && function.Inverted)
                spec = spec.Not();

            return spec;
        }

        ISpecificationExpression<Ticket> GetSpecFromPredicateAndValue(PredicateAndValue predicateAndValue)
        {
            return comparisonSpecFactory
                .GetFromPredicateName(predicateAndValue.PredicateText,
                                      valueResolver.Resolve<int>(predicateAndValue.Value));
        }

        public CriterionToSpecificationConversionStrategyMetadata GetMetadata()
            => new StoryPointsConversionStrategyMetadata();

        public StoryPointsConversionStrategy(IResolvesValue valueResolver, IGetsStoryPointsComparisonSpec comparisonSpecFactory)
        {
            this.valueResolver = valueResolver ?? throw new ArgumentNullException(nameof(valueResolver));
            this.comparisonSpecFactory = comparisonSpecFactory ?? throw new ArgumentNullException(nameof(comparisonSpecFactory));
        }

        class StoryPointsConversionStrategyMetadata : CriterionToSpecificationConversionStrategyMetadata
        {
            public override bool CanConvertAsPredicateFunction(string elementName, string predicateFunctionName, int parameterCount)
            {
                if(elementName != ElementName.StoryPoints) return false;

                if(predicateFunctionName == PredicateName.Function.IsEmpty && parameterCount == 0)
                    return true;

                if(predicateFunctionName == PredicateName.Function.IsAnyOf) return true;

                return false;
            }

            public override bool CanConvertAsPredicateWithValue(string elementName, string predicateText)
            {
                var acceptablePredicates = new[] {
                    PredicateName.Equals,
                    PredicateName.NotEquals,
                    PredicateName.GreaterThan,
                    PredicateName.GreaterThanOrEqual,
                    PredicateName.LessThan,
                    PredicateName.LessThanOrEqual,
                };
                return (elementName == ElementName.StoryPoints
                        && acceptablePredicates.Contains(predicateText));
            }
        }
    }
}
