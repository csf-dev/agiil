using System;
using System.Reflection;
using Agiil.Domain.TicketSearch;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.NUnit3;

namespace Agiil.Tests.Attributes
{
  [AttributeUsage(AttributeTargets.Parameter)]
  public class MockedMetadataAttribute : CustomizeAttribute
  {
    public override ICustomization GetCustomization(ParameterInfo parameter)
    {
      if(parameter.ParameterType != typeof(IStrategyForConvertingCriterionToSpecification))
      {
        throw new InvalidOperationException($"`{nameof(MockedMetadataAttribute)}' is only valid for `{nameof(IStrategyForConvertingCriterionToSpecification)}' parameters.");
      }

      return new MockedMetadataCustomization();
    }

    class MockedMetadataCustomization : ICustomization
    {
      public void Customize(IFixture fixture)
      {
        fixture.Customize<IStrategyForConvertingCriterionToSpecification>(c => {
          return c
            .FromFactory(() => Mock.Of<IStrategyForConvertingCriterionToSpecification>())
            .Do(strategy => {
              var meta = new Mock<CriterionToSpecificationConversionStrategyMetadata>() {
                CallBase = true,
              };
            Mock.Get(strategy).Setup(x => x.GetMetadata()).Returns(meta.Object);
            });
        });
      }
    }
  }
}
