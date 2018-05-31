using System;
using System.Linq.Expressions;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets
{
  public class TicketReferenceSpecification : SpecificationExpression<Ticket>
  {
    readonly TicketReference reference;

    public override Expression<Func<Ticket, bool>> GetExpression()
    {
      return ticket => ticket.Project != null
                       && ticket.Project.Code == reference.ProjectCode
                       && ticket.TicketNumber == reference.TicketNumber;
    }

    public TicketReferenceSpecification(TicketReference reference)
    {
      if(reference == null)
        throw new ArgumentNullException(nameof(reference));
      this.reference = reference;
    }
  }
}
