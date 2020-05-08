using System;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
  public class HasNoSprint : ISpecificationExpression<Ticket>
  {
    public Expression<Func<Ticket, bool>> GetExpression()
      => ticket => ticket.Sprint == null;
  }
}
