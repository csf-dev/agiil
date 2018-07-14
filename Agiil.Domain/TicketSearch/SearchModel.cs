using System;
using Agiil.Domain.Tickets;
using CSF.Data.Specifications;

namespace Agiil.Domain.TicketSearch
{
  public class SearchModel : ChildNodeProvider, IGetsTicketSpecification
  {
    public ISpecificationExpression<Ticket> GetSpecification()
    {
      ISpecificationExpression<Ticket> output = null;

      foreach(var child in Children)
      {
        var spec = child?.GetSpecification();
        if(spec == null) continue;

        output = (output == null)? spec : output.And(spec);
      }

      return output ?? new DynamicSpecificationExpression<Ticket>(x => true);
    }
  }
}
