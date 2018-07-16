using System;
namespace Agiil.QueryLanguage
{
  public class PredicateFunction : Function, IDescribesPredicate
  {
    public bool Inverted { get; set; }

    string IDescribesPredicate.PredicateText => FunctionName;
  }
}
