using Agiil.Domain.TicketCriterionConvertionStrategies;
using Agiil.Domain.Tickets.Specs;
using Agiil.Domain.TicketSearch;
using Agiil.Tests.Attributes;
using Moq;
using NUnit.Framework;
using AutoFixture.NUnit3;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agiil.Tests.TicketCriterionConvertionStrategies
{
  [TestFixture,Parallelizable]
  public class HasAllLabelsConversionStrategyTests
  {
    [Test,AutoMoqData]
    public void GetMetadata_returns_metadata_which_matches_a_criterion_for_labels_hasallof_some_parameters()
    {
      // Arrange
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("labels", "hasallof", "one", "two");
      var sut = HasAllLabelsConversionStrategy.GetMetadata();

      // Act
      var result = sut.CanConvert(criterion);

      // Assert
      Assert.That(result, Is.True);
    }

    [Test,AutoMoqData]
    public void GetMetadata_returns_metadata_which_does_not_match_a_criterion_with_no_parameters()
    {
      // Arrange
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("labels", "hasallof");
      var sut = HasAllLabelsConversionStrategy.GetMetadata();

      // Act
      var result = sut.CanConvert(criterion);

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void GetMetadata_returns_metadata_which_does_not_match_a_criterion_for_the_element_ticket()
    {
      // Arrange
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("ticket", "hasallof", "one", "two");
      var sut = HasAllLabelsConversionStrategy.GetMetadata();

      // Act
      var result = sut.CanConvert(criterion);

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void GetMetadata_returns_metadata_which_does_not_match_a_criterion_for_the_predicate_function_hasanyof()
    {
      // Arrange
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("labels", "hasanyof", "one", "two");
      var sut = HasAllLabelsConversionStrategy.GetMetadata();

      // Act
      var result = sut.CanConvert(criterion);

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void ConvertToSpecification_resolves_all_values_using_resolver([Frozen] IResolvesValue resolver,
                                                                          HasAllLabelsConversionStrategy sut,
                                                                          string[] resolvedValues)
    {
      // Arrange
      Mock.Get(resolver)
          .Setup(x => x.ResolveAll<string>(It.IsAny<IReadOnlyList<Value>>()))
          .Returns(resolvedValues);
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("labels", "hasallof", "one", "two");
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
    public void ConvertToSpecification_returns_instance_of_spec([Frozen] IResolvesValue resolver,
                                                                HasAllLabelsConversionStrategy sut,
                                                                string[] paramValues,
                                                                string[] resolvedValues)
    {
      // Arrange
      Mock.Get(resolver)
          .Setup(x => x.ResolveAll<string>(It.IsAny<IReadOnlyList<Value>>()))
          .Returns(resolvedValues);
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("labels", "hasallof", paramValues);

      // Act
      var result = sut.ConvertToSpecification(criterion);

      // Assert
      Assert.That(result, Is.Not.Null);
      Assert.That(result, Is.InstanceOf<HasAllLabels>());
    }

    [Test,AutoMoqData]
    public void ConvertToSpecification_initialises_label_names_with_resolved_values([Frozen] IResolvesValue resolver,
                                                                                    HasAllLabelsConversionStrategy sut,
                                                                                    string[] paramValues,
                                                                                    string[] resolvedValues)
    {
      // Arrange
      Mock.Get(resolver)
          .Setup(x => x.ResolveAll<string>(It.IsAny<IReadOnlyList<Value>>()))
          .Returns(resolvedValues);
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("labels", "hasallof", paramValues);

      // Act
      var result = sut.ConvertToSpecification(criterion);

      // Assert
      Assert.That((result as HasAllLabels)?.LabelNames, Is.EqualTo(resolvedValues));
    }
  }
}
