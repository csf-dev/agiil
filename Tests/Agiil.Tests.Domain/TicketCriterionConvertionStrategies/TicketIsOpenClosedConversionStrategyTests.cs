using Agiil.Domain.TicketCriterionConvertionStrategies;
using Agiil.Domain.Tickets.Specs;
using Agiil.Domain.TicketSearch;
using Agiil.Tests.Attributes;
using Moq;
using NUnit.Framework;
using AutoFixture.NUnit3;
using System;
namespace Agiil.Tests.TicketCriterionConvertionStrategies
{
  [TestFixture()]
  public class TicketIsOpenClosedConversionStrategyTests
  {
    [Test,AutoMoqData]
    public void GetMetadata_returns_metadata_which_matches_a_criterion_for_ticket_is_and_one_parameter()
    {
      // Arrange
      var criterion = Criterion.FromElementPredicateAndConstantValue("ticket", "is", "foo");
      var sut = TicketIsOpenClosedConversionStrategy.GetMetadata();

      // Act
      var result = sut.CanConvert(criterion);

      // Assert
      Assert.That(result, Is.True);
    }

    [Test,AutoMoqData]
    public void GetMetadata_returns_metadata_which_does_not_match_a_criterion_for_element_sprint()
    {
      // Arrange
      var criterion = Criterion.FromElementPredicateAndConstantValue("sprint", "is", "foo");
      var sut = TicketIsOpenClosedConversionStrategy.GetMetadata();

      // Act
      var result = sut.CanConvert(criterion);

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void GetMetadata_returns_metadata_which_does_not_match_a_criterion_for_predicate_equals()
    {
      // Arrange
      var criterion = Criterion.FromElementPredicateAndConstantValue("ticket", "=", "foo");
      var sut = TicketIsOpenClosedConversionStrategy.GetMetadata();

      // Act
      var result = sut.CanConvert(criterion);

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void ConvertToSpecification_returns_instance_of_IsClosed_if_value_is_closed([Frozen] IResolvesValue resolver,
                                                                                       TicketIsOpenClosedConversionStrategy sut,
                                                                                       string inputValue)
    {
      // Arrange
      Mock.Get(resolver)
          .Setup(x => x.Resolve<string>(It.IsAny<Value>()))
          .Returns(WellKnownValue.Closed);
      var criterion = Criterion.FromElementPredicateAndConstantValue("ticket", "is", inputValue);

      // Act
      var result = sut.ConvertToSpecification(criterion);

      // Assert
      Assert.That(result, Is.InstanceOf<IsClosed>());
    }

    [Test,AutoMoqData]
    public void ConvertToSpecification_returns_instance_of_IsOpen_if_value_is_not_closed([Frozen] IResolvesValue resolver,
                                                                                         TicketIsOpenClosedConversionStrategy sut,
                                                                                         string inputValue)
    {
      // Arrange
      Mock.Get(resolver)
          .Setup(x => x.Resolve<string>(It.IsAny<Value>()))
          .Returns("somethingelse");
      var criterion = Criterion.FromElementPredicateAndConstantValue("ticket", "is", inputValue);

      // Act
      var result = sut.ConvertToSpecification(criterion);

      // Assert
      Assert.That(result, Is.InstanceOf<IsOpen>());
    }
  }
}
