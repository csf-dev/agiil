using System;
namespace Agiil.QueryLanguage
{
  public interface IDescribesPredicate
  {
    bool Inverted { get; }

    string PredicateText { get; }
  }
}
