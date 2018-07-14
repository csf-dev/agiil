using System;
using Agiil.Domain.Tickets.Specs;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets
{
  public class TicketListSpecificationFromRequestAdapter : IGetsTicketSpecification
  {
    readonly TicketListRequest request;

    public ISpecificationExpression<Ticket> GetSpecification()
      => request.CriteriaModel.GetSpecification();

    public TicketListSpecificationFromRequestAdapter(TicketListRequest request)
    {
      if(request == null)
        throw new ArgumentNullException(nameof(request));
      this.request = request;
    }
  }
}
