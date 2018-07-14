using System;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
  public class HasNoSprint : SpecificationExpression<Ticket>
  {
    public override Expression<Func<Ticket, bool>> GetExpression()
      => ticket => ticket.Sprint == null;
  }
}
