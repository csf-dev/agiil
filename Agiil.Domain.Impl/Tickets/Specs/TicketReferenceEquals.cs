using System;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
  public class TicketReferenceEquals : SpecificationExpression<Ticket>
  {
    readonly TicketReference reference;

    public override Expression<Func<Ticket, bool>> GetExpression()
    {
      return ticket => ticket.Project != null
                       && ticket.Project.Code == reference.ProjectCode
                       && ticket.TicketNumber == reference.TicketNumber;
    }

    public TicketReferenceEquals(TicketReference reference)
    {
      if(reference == null)
        throw new ArgumentNullException(nameof(reference));
      this.reference = reference;
    }
  }
}
