using System;
namespace Agiil.Domain.TicketSearch
{
  public class PredicateAndValue : IDescribesPredicate
  {
    public bool Inverted => false;

    public string PredicateText { get; set; }

    public Value Value { get; set; }

    public void Accept(IVisitsTicketSearch visitor) { visitor?.Visit(this); }
  }
}
