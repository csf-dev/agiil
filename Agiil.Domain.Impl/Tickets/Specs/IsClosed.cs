using System;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
  public class IsClosed : SpecificationExpression<Ticket>
  {
    public override Expression<Func<Ticket, bool>> GetExpression()
    {
      return ticket => ticket.Closed;
    }
  }
}
