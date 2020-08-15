using System;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
    public interface ISpecForTicketTypeNameEquality : ISpecificationExpression<Ticket> { }

    public class TicketTypeNameEquals : ISpecForTicketTypeNameEquality
    {
        readonly string name;

        public Expression<Func<Ticket, bool>> GetExpression()
            => ticket => ticket.Type.Name == name;

        public TicketTypeNameEquals(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
