using System;
namespace Agiil.Domain.Tickets
{
  public interface IGetsTicketSpecificationProvider
  {
    IGetsTicketSpecification GetFromListRequest(TicketListRequest request);
  }
}
