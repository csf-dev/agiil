using Agiil.Domain.TicketCriterionConvertionStrategies;
using Agiil.Domain.Tickets.Specs;
using Agiil.Domain.TicketSearch;
using Agiil.Tests.Attributes;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture.NUnit3;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agiil.Tests.TicketCriterionConvertionStrategies
{
  [TestFixture,Parallelizable]
  public class HasLabelConversionStrategyTests
  {
    [Test,AutoMoqData]
    public void GetMetadata_returns_metadata_which_matches_a_criterion_for_labels_hasanyof_some_parameters()
    {
      // Arrange
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("labels", "hasanyof", "one", "two");
      var sut = HasLabelConversionStrategy.GetMetadata();

      // Act
      var result = sut.CanConvert(criterion);

      // Assert
      Assert.That(result, Is.True);
    }

    [Test,AutoMoqData]
    public void GetMetadata_returns_metadata_which_matches_a_criterion_for_label_equals_a_constant()
    {
      // Arrange
      var criterion = Criterion.FromElementPredicateAndConstantValue("label", "=", "one");
      var sut = HasLabelConversionStrategy.GetMetadata();

      // Act
      var result = sut.CanConvert(criterion);

      // Assert
      Assert.That(result, Is.True);
    }

    [Test,AutoMoqData]
    public void GetMetadata_returns_metadata_which_does_not_match_a_criterion_with_no_parameters()
    {
      // Arrange
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("labels", "hasanyof");
      var sut = HasLabelConversionStrategy.GetMetadata();

      // Act
      var result = sut.CanConvert(criterion);

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void GetMetadata_returns_metadata_which_does_not_match_a_criterion_for_the_element_ticket()
    {
      // Arrange
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("ticket", "hasanyof", "one", "two");
      var sut = HasLabelConversionStrategy.GetMetadata();

      // Act
      var result = sut.CanConvert(criterion);

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void GetMetadata_returns_metadata_which_does_not_match_a_criterion_for_the_predicate_function_hasallof()
    {
      // Arrange
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("labels", "hasallof", "one", "two");
      var sut = HasLabelConversionStrategy.GetMetadata();

      // Act
      var result = sut.CanConvert(criterion);

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void ConvertToSpecification_from_func_resolves_all_values_using_resolver([Frozen] IResolvesValue resolver,
                                                                          HasLabelConversionStrategy sut,
                                                                          string[] resolvedValues)
    {
      // Arrange
      Mock.Get(resolver)
          .Setup(x => x.ResolveAll<string>(It.IsAny<IReadOnlyList<Value>>()))
          .Returns(resolvedValues);
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("labels", "hasanyof", "one", "two");
      var expectedParams = new [] {
        ConstantValue.FromConstant("one"),
        ConstantValue.FromConstant("two"),
      }
        .Cast<Value>()
        .ToList();

      // Act
      sut.ConvertToSpecification(criterion);

      // Assert
      Mock.Get(resolver).Verify(x => x.ResolveAll<string>(expectedParams), Times.Once);
    }

    [Test,AutoMoqData]
    public void ConvertToSpecification_from_func_returns_instance_of_spec([Frozen] IResolvesValue resolver,
                                                                          HasLabelConversionStrategy sut,
                                                                          string[] paramValues,
                                                                          string[] resolvedValues)
    {
      // Arrange
      Mock.Get(resolver)
          .Setup(x => x.ResolveAll<string>(It.IsAny<IReadOnlyList<Value>>()))
          .Returns(resolvedValues);
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("labels", "hasanyof", paramValues);

      // Act
      var result = sut.ConvertToSpecification(criterion);

      // Assert
      Assert.That(result, Is.Not.Null);
      Assert.That(result, Is.InstanceOf<HasLabel>());
    }

    [Test,AutoMoqData]
    public void ConvertToSpecification_from_func_initialises_label_names_with_resolved_values([Frozen] IResolvesValue resolver,
                                                                                              HasLabelConversionStrategy sut,
                                                                                              string[] paramValues,
                                                                                              string[] resolvedValues)
    {
      // Arrange
      Mock.Get(resolver)
          .Setup(x => x.ResolveAll<string>(It.IsAny<IReadOnlyList<Value>>()))
          .Returns(resolvedValues);
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("labels", "hasanyof", paramValues);

      // Act
      var result = sut.ConvertToSpecification(criterion);

      // Assert
      Assert.That((result as HasLabel)?.LabelNames, Is.EqualTo(resolvedValues));
    }

    [Test,AutoMoqData]
    public void ConvertToSpecification_from_const_resolves_value_using_resolver([Frozen] IResolvesValue resolver,
                                                                                HasLabelConversionStrategy sut,
                                                                                string inputValue,
                                                                                string resolvedValue)
    {
      // Arrange
      Mock.Get(resolver)
          .Setup(x => x.Resolve<string>(It.IsAny<Value>()))
          .Returns(resolvedValue);
      var criterion = Criterion.FromElementPredicateAndConstantValue("label", "=", inputValue);
      var expectedParam = ConstantValue.FromConstant(inputValue);

      // Act
      sut.ConvertToSpecification(criterion);

      // Assert
      Mock.Get(resolver).Verify(x => x.Resolve<string>(expectedParam), Times.Once);
    }

    [Test,AutoMoqData]
    public void ConvertToSpecification_from_const_returns_instance_of_spec([Frozen] IResolvesValue resolver,
                                                                           HasLabelConversionStrategy sut,
                                                                           string inputValue,
                                                                           string resolvedValue)
    {
      // Arrange
      Mock.Get(resolver)
          .Setup(x => x.Resolve<string>(It.IsAny<Value>()))
          .Returns(resolvedValue);
      var criterion = Criterion.FromElementPredicateAndConstantValue("label", "=", inputValue);

      // Act
      var result = sut.ConvertToSpecification(criterion);

      // Assert
      Assert.That(result, Is.Not.Null);
      Assert.That(result, Is.InstanceOf<HasLabel>());
    }

    [Test,AutoMoqData]
    public void ConvertToSpecification_from_const_initialises_label_names_with_resolved_values([Frozen] IResolvesValue resolver,
                                                                                               HasLabelConversionStrategy sut,
                                                                                               string inputValue,
                                                                                               string resolvedValue)
    {
      // Arrange
      Mock.Get(resolver)
          .Setup(x => x.Resolve<string>(It.IsAny<Value>()))
          .Returns(resolvedValue);
      var criterion = Criterion.FromElementPredicateAndConstantValue("label", "=", inputValue);

      // Act
      var result = sut.ConvertToSpecification(criterion);

      // Assert
      Assert.That((result as HasLabel)?.LabelNames, Is.EqualTo(new [] { resolvedValue }));
    }
  }
}
