using System;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets
{
  public class IsOpen : SpecificationExpression<Ticket>
  {
    public override Expression<Func<Ticket, bool>> GetExpression()
    {
      return ticket => !ticket.Closed;
    }
  }
}
