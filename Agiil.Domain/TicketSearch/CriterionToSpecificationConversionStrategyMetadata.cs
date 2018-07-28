using System;
namespace Agiil.Domain.TicketSearch
{
  public class CriterionToSpecificationConversionStrategyMetadata
  {
    public virtual bool CanConvert(Criterion criterion)
    {
      if(criterion?.Test == null) return false;

      return CanConvertAsPredicateWithValue(criterion) || CanConvertAsPredicateFunction(criterion);
    }

    public virtual bool CanConvertAsPredicateWithValue(Criterion criterion)
    {
      var predicateAndValue = GetPredicateAndValue(criterion);
      if(predicateAndValue == null) return false;

      return CanConvertAsPredicateWithValue(criterion.ElementName, predicateAndValue.PredicateText);
    }

    public virtual bool CanConvertAsPredicateFunction(Criterion criterion)
    {
      var predicateFunction = GetPredicateFunction(criterion);
      if(predicateFunction == null) return false;

      return CanConvertAsPredicateFunction(criterion.ElementName,
                                           predicateFunction.FunctionName,
                                           (predicateFunction.Parameters?.Count).GetValueOrDefault());
    }

    public virtual bool CanConvertAsPredicateWithValue(string elementName, string predicateText)
      => false;

    public virtual bool CanConvertAsPredicateFunction(string elementName, string predicateFunctionName, int parameterCount)
      => false;

    protected PredicateAndValue GetPredicateAndValue(Criterion criterion)
    {
      return criterion?.Test as PredicateAndValue;
    }

    protected PredicateFunction GetPredicateFunction(Criterion criterion)
    {
      return criterion?.Test as PredicateFunction;
    }
  }
}
