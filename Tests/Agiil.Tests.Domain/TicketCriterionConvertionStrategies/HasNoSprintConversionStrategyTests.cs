using Agiil.Domain.TicketCriterionConvertionStrategies;
using Agiil.Domain.Tickets.Specs;
using Agiil.Domain.TicketSearch;
using Agiil.Tests.Attributes;
using NUnit.Framework;
using System;
namespace Agiil.Tests.TicketCriterionConvertionStrategies
{
  [TestFixture()]
  public class HasNoSprintConversionStrategyTests
  {
    [Test,AutoMoqData]
    public void GetMetadata_returns_metadata_which_matches_a_criterion_for_sprint_isempty_and_no_parameters()
    {
      // Arrange
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("sprint", "isempty");
      var sut = HasNoSprintConversionStrategy.GetMetadata();

      // Act
      var result = sut.CanConvert(criterion);

      // Assert
      Assert.That(result, Is.True);
    }

    [Test,AutoMoqData]
    public void GetMetadata_returns_metadata_which_does_not_match_a_criterion_with_any_parameters()
    {
      // Arrange
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("sprint", "isempty", "one");
      var sut = HasNoSprintConversionStrategy.GetMetadata();

      // Act
      var result = sut.CanConvert(criterion);

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void GetMetadata_returns_metadata_which_does_not_match_a_criterion_for_the_element_ticket()
    {
      // Arrange
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("ticket", "isempty");
      var sut = HasNoSprintConversionStrategy.GetMetadata();

      // Act
      var result = sut.CanConvert(criterion);

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void GetMetadata_returns_metadata_which_does_not_match_a_criterion_for_the_function_hasanyof()
    {
      // Arrange
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("sprint", "hasanyof");
      var sut = HasNoSprintConversionStrategy.GetMetadata();

      // Act
      var result = sut.CanConvert(criterion);

      // Assert
      Assert.That(result, Is.False);
    }

    [Test,AutoMoqData]
    public void ConvertToSpecification_returns_instance_of_spec(HasNoSprintConversionStrategy sut)
    {
      // Arrange
      var criterion = Criterion.FromElementAndPredicateFunctionWithConstantValues("sprint", "isempty");

      // Act
      var result = sut.ConvertToSpecification(criterion);

      // Assert
      Assert.That(result, Is.Not.Null);
      Assert.That(result, Is.InstanceOf<HasNoSprint>());
    }
  }
}
