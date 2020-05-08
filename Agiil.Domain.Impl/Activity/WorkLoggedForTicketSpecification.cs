using System;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Domain.Activity
{
  public class WorkLoggedForTicketSpecification : ISpecificationExpression<TicketWorkLog>
  {
    readonly Tickets.Ticket ticket;

    public WorkLoggedForTicketSpecification(Tickets.Ticket ticket)
    {
      if(ticket == null)
        throw new ArgumentNullException(nameof(ticket));
      this.ticket = ticket;
    }

    public Expression<Func<TicketWorkLog, bool>> GetExpression()
    {
      return x => x.Ticket == ticket;
    }
  }
}
