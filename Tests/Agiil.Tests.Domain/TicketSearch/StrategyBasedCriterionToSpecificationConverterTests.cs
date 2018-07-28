using Agiil.Domain.Tickets;
using Agiil.Domain.TicketSearch;
using Agiil.Tests.Attributes;
using CSF.Data.Specifications;
using Moq;
using NUnit.Framework;
using System;
namespace Agiil.Tests.TicketSearch
{
  [TestFixture,Parallelizable]
  public class StrategyBasedCriterionToSpecificationConverterTests
  {
    [Test,AutoMoqData]
    public void ConvertToSpecification_uses_a_viable_strategy(Criterion criterion,
                                                              [MockedMetadata] IStrategyForConvertingCriterionToSpecification one,
                                                              [MockedMetadata] IStrategyForConvertingCriterionToSpecification two,
                                                              [MockedMetadata] IStrategyForConvertingCriterionToSpecification three,
                                                              ISpecificationExpression<Ticket> spec)
    {
      // Arrange
      var strategies = new [] { one, two, three };
      var sut = new StrategyBasedCriterionToSpecificationConverter(strategies);

      Mock.Get(two.GetMetadata()).Setup(x => x.CanConvert(criterion)).Returns(true);
      Mock.Get(two).Setup(x => x.ConvertToSpecification(criterion)).Returns(spec);

      // Act
      var result = sut.ConvertToSpecification(criterion);

      // Assert
      Assert.That(result, Is.SameAs(spec));
    }

    [Test,AutoMoqData]
    public void ConvertToSpecification_uses_first_viable_strategy(Criterion criterion,
                                                                  [MockedMetadata] IStrategyForConvertingCriterionToSpecification one,
                                                                  [MockedMetadata] IStrategyForConvertingCriterionToSpecification two,
                                                                  [MockedMetadata] IStrategyForConvertingCriterionToSpecification three,
                                                                  ISpecificationExpression<Ticket> spec)
    {
      // Arrange
      var strategies = new [] { one, two, three };
      var sut = new StrategyBasedCriterionToSpecificationConverter(strategies);

      Mock.Get(two.GetMetadata()).Setup(x => x.CanConvert(criterion)).Returns(true);
      Mock.Get(two).Setup(x => x.ConvertToSpecification(criterion)).Returns(spec);
      Mock.Get(three.GetMetadata()).Setup(x => x.CanConvert(criterion)).Returns(true);
      Mock.Get(three).Setup(x => x.ConvertToSpecification(criterion)).Returns(spec);

      // Act
      var result = sut.ConvertToSpecification(criterion);

      // Assert
      Mock.Get(two).Verify(x => x.ConvertToSpecification(criterion), Times.Once);
      Mock.Get(three).Verify(x => x.ConvertToSpecification(criterion), Times.Never);
    }

    [Test,AutoMoqData]
    public void ConvertToSpecification_returns_null_when_no_viable_strategy(Criterion criterion,
                                                                            [MockedMetadata] IStrategyForConvertingCriterionToSpecification one,
                                                                            [MockedMetadata] IStrategyForConvertingCriterionToSpecification two,
                                                                            [MockedMetadata] IStrategyForConvertingCriterionToSpecification three)
    {
      // Arrange
      var strategies = new [] { one, two, three };
      var sut = new StrategyBasedCriterionToSpecificationConverter(strategies);

      // Act
      var result = sut.ConvertToSpecification(criterion);

      // Assert
      Assert.That(result, Is.Null);
    }

  }
}
