using System;
namespace Agiil.QueryLanguage
{
  public class PredicateAndValue : IDescribesPredicate
  {
    public bool Inverted => false;

    public string PredicateText { get; set; }

    public Value Value { get; set; }
  }
}
