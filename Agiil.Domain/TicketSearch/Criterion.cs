using System;
namespace Agiil.Domain.TicketSearch
{
  public class Criterion : LogicalCriterion
  {
    public string ElementName { get; set; }

    public IDescribesPredicate Test { get; set; }

    public override void Accept(IVisitsTicketSearch visitor) { visitor?.Visit(this); }
  }
}
