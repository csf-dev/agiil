using System;
using System.Linq;

namespace Agiil.Domain.TicketSearch
{
  public class Criterion : LogicalCriterion
  {
    public string ElementName { get; set; }

    public IDescribesPredicate Test { get; set; }

    public override void Accept(IVisitsTicketSearch visitor) { visitor?.Visit(this); }

    public static Criterion FromElementPredicateAndConstantValue(string elementName, string predicate, string value)
    {
      return new Criterion {
        ElementName = elementName,
        Test = new PredicateAndValue {
          PredicateText = predicate,
          Value = ConstantValue.FromConstant(value),
        },
      };
    }

    public static Criterion FromElementAndPredicateFunctionWithConstantValues(string elementName,
                                                                              string predicateFunction,
                                                                              params string[] values)
    {
      return new Criterion {
        ElementName = elementName,
        Test = new PredicateFunction {
          FunctionName = predicateFunction,
          Parameters = values.Select(x => ConstantValue.FromConstant(x)).Cast<Value>().ToList(),
        },
      };
    }
  }
}
