using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
    public interface ISpecForTicketTypeNameAnyOf : ISpecificationExpression<Ticket> { }

    public class TicketTypeNameIsAnyOf : ISpecForTicketTypeNameAnyOf
    {
        readonly IEnumerable<string> names;

        public Expression<Func<Ticket, bool>> GetExpression()
            => ticket => names.Contains(ticket.Type.Name);

        public TicketTypeNameIsAnyOf(IEnumerable<string> names)
        {
            this.names = names ?? throw new ArgumentNullException(nameof(names));
        }
    }
}
