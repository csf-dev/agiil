using System;
using System.Collections.Generic;
using Agiil.Domain.Tickets;
using Agiil.Domain.Tickets.Specs;
using CSF.Data.Specifications;

namespace Agiil.Domain.TicketSearch
{
  /// <summary>
  /// A search node indicating that the ticket's type must be one of the named types.
  /// </summary>
  public class IsTicketTypeNode : SearchNode, IGetsTicketSpecification
  {
    ICollection<string> typeNames;

    public ICollection<string> TypeNames
    {
      get { return typeNames; }
      set { typeNames = value ?? new List<string>(); }
    }

    public ISpecificationExpression<Ticket> GetSpecification() => new IsTicketType(typeNames);
  }
}
