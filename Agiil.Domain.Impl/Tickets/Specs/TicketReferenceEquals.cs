using System;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
    public interface ISpecForTicketReferenceEquality : ISpecificationExpression<Ticket> { }

    public class TicketReferenceEquals : ISpecForTicketReferenceEquality
    {
        readonly TicketReference reference;

        public Expression<Func<Ticket, bool>> GetExpression()
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
