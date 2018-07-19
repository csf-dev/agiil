using System;
namespace Agiil.Domain.TicketSearch
{
  public class PredicateFunction : Function, IDescribesPredicate
  {
    public bool Inverted { get; set; }

    string IDescribesPredicate.PredicateText => FunctionName;
  }
}
