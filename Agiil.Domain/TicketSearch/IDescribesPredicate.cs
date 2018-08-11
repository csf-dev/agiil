using System;
namespace Agiil.Domain.TicketSearch
{
  public interface IDescribesPredicate
  {
    bool Inverted { get; }

    string PredicateText { get; }
  }
}
