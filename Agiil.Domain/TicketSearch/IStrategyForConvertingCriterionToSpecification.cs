using System;
namespace Agiil.Domain.TicketSearch
{
  public interface IStrategyForConvertingCriterionToSpecification : IConvertsCriterionToSpecification
  {
    bool CanConvertPredicateWithValue(string elementName, string predicateName);

    bool CanConvertPredicateFunction(string elementName, string predicateFunctionName, int parameterCount);
  }
}
