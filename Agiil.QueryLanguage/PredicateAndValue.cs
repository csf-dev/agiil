using System;
namespace Agiil.QueryLanguage
{
  public class PredicateAndValue : IDescribesPredicate
  {
    public bool Inverted { get; set; }

    public string PredicateText { get; set; }

    public Value Value { get; set; }
  }
}
