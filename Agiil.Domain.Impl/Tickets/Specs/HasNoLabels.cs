using System;
using System.Linq;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
  public class HasNoLabels : ISpecificationExpression<Ticket>
  {
    public Expression<Func<Ticket, bool>> GetExpression()
      => ticket => !ticket.Labels.Any();
  }
}
