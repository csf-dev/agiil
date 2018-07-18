using System;
namespace Agiil.QueryLanguage
{
  public class Criterion : LogicalCriterion
  {
    public string ElementName { get; set; }

    public IDescribesPredicate Test { get; set; }
  }
}
