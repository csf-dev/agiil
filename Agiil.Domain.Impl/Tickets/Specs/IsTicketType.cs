using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
  public class IsTicketType : ISpecificationExpression<Ticket>
  {
    readonly string[] ticketTypeNames;

    public Expression<Func<Ticket, bool>> GetExpression()
    => ticket => ticket.Type != null && ticketTypeNames.Contains(ticket.Type.Name);

    public IsTicketType(string ticketTypeNames) : this(new [] {ticketTypeNames}) {}

    public IsTicketType(IEnumerable<string> ticketTypeNames)
    {
      if(ticketTypeNames == null)
        throw new ArgumentNullException(nameof(ticketTypeNames));

      this.ticketTypeNames = ticketTypeNames.ToArray();
    }
  }
}
