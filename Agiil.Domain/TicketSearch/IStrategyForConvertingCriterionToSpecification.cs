using System;
namespace Agiil.Domain.TicketSearch
{
  public interface IStrategyForConvertingCriterionToSpecification : IConvertsCriterionToSpecification
  {
    CriterionToSpecificationConversionStrategyMetadata GetMetadata();
  }
}
