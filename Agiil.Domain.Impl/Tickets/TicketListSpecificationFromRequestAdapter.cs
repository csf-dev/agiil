using System;
using Agiil.Domain.Tickets.Specs;
using CSF.Data.Specifications;

namespace Agiil.Domain.Tickets
{
  public class TicketListSpecificationFromRequestAdapter : IGetsTicketSpecification
  {
    readonly TicketListRequest request;

    public ISpecificationExpression<Ticket> GetSpecification()
    {
      if(request.ShowOpenTickets && !request.ShowClosedTickets)
        return new IsOpen();

      if(!request.ShowOpenTickets && request.ShowClosedTickets)
        return new IsClosed();

      if(request.ShowOpenTickets && request.ShowClosedTickets)
        return GetTrueSpecification();

      return GetFalseSpecification();
    }

    ISpecificationExpression<Ticket> GetFalseSpecification()
      => new DynamicSpecificationExpression<Ticket>(t => false);

    ISpecificationExpression<Ticket> GetTrueSpecification()
      => new DynamicSpecificationExpression<Ticket>(t => true);

    public TicketListSpecificationFromRequestAdapter(TicketListRequest request)
    {
      if(request == null)
        throw new ArgumentNullException(nameof(request));
      this.request = request;
    }
  }
}
