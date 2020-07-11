using System;
using Agiil.Domain.TicketCriterionConvertionStrategies;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using Agiil.Domain.TicketSearch;
using Agiil.Tests.Attributes;
using AutoFixture.NUnit3;
using CSF.Specifications;
using Moq;
using NUnit.Framework;

namespace Agiil.Tests.TicketCriterionConvertionStrategies
{
    [TestFixture, Parallelizable]
    public class StoryPointsConversionStrategyTests
    {
        [Test, AutoMoqData]
        public void GetMetadata_indicates_it_can_convert_for_all_supported_predicate_names_and_values(StoryPointsConversionStrategy sut, int value)
        {
            var supportedPredicates = new[] {
                PredicateName.Equals,
                PredicateName.NotEquals,
                PredicateName.GreaterThan,
                PredicateName.GreaterThanOrEqual,
                PredicateName.LessThan,
                PredicateName.LessThanOrEqual,
            };
            foreach(var predicate in supportedPredicates)
            {
                var criterion = Criterion.FromElementPredicateAndConstantValue(ElementName.StoryPoints, predicate, value.ToString());
                Assert.That(() => sut.GetMetadata().CanConvertAsPredicateWithValue(criterion), Is.True, $"Can convert for predicate '{predicate}'");
            }
        }

        [Test, AutoMoqData]
        public void GetMetadata_indicates_it_can_convert_for_an_isempty_function(StoryPointsConversionStrategy sut)
        {
            var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues(ElementName.StoryPoints, PredicateName.Function.IsEmpty);
            Assert.That(() => sut.GetMetadata().CanConvertAsPredicateFunction(criterion), Is.True);
        }

        [Test, AutoMoqData]
        public void GetMetadata_indicates_it_can_convert_for_an_isanyof_function(StoryPointsConversionStrategy sut, int value1, int value2)
        {
            var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues(ElementName.StoryPoints, PredicateName.Function.IsAnyOf, value1.ToString(), value2.ToString());
            Assert.That(() => sut.GetMetadata().CanConvertAsPredicateFunction(criterion), Is.True);
        }

        [Test, AutoMoqData]
        public void ConvertToSpecification_returns_a_spec_when_converting_a_predicate_and_value([Frozen] IGetsStoryPointsComparisonSpec specFactory,
                                                                                                [Frozen] IResolvesValue resolver,
                                                                                                ISpecificationExpression<Ticket> spec,
                                                                                                StoryPointsConversionStrategy sut,
                                                                                                int value)
        {
            Mock.Get(specFactory).Setup(x => x.GetFromPredicateName(PredicateName.GreaterThan, value)).Returns(spec);
            var criterion = Criterion.FromElementPredicateAndConstantValue(ElementName.StoryPoints, PredicateName.GreaterThan, value.ToString());
            Mock.Get(resolver).Setup(x => x.Resolve<int>(((PredicateAndValue) criterion.Test).Value)).Returns(value);
            Assert.That(() => sut.ConvertToSpecification(criterion), Is.SameAs(spec));
        }

        [Test, AutoMoqData]
        public void ConvertToSpecification_returns_a_spec_when_converting_an_isempty_function(StoryPointsConversionStrategy sut)
        {
            var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues(ElementName.StoryPoints, PredicateName.Function.IsEmpty);
            Assert.That(() => sut.ConvertToSpecification(criterion), Is.InstanceOf<HasNoStoryPoints>());
        }

        [Test, AutoMoqData]
        public void ConvertToSpecification_returns_a_spec_when_converting_an_isanyof_function(StoryPointsConversionStrategy sut, int value)
        {
            var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues(ElementName.StoryPoints, PredicateName.Function.IsAnyOf, value.ToString());
            Assert.That(() => sut.ConvertToSpecification(criterion), Is.InstanceOf<StoryPointsIsOneOf>());
        }
    }
}
