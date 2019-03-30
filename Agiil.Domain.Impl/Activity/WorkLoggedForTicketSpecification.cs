using System;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Domain.Activity
{
  public class WorkLoggedForTicketSpecification : SpecificationExpression<TicketWorkLog>
  {
    readonly Tickets.Ticket ticket;

    public WorkLoggedForTicketSpecification(Tickets.Ticket ticket)
    {
      if(ticket == null)
        throw new ArgumentNullException(nameof(ticket));
      this.ticket = ticket;
    }

    public override Expression<Func<TicketWorkLog, bool>> GetExpression()
    {
      return x => x.Ticket == ticket;
    }
  }
}
