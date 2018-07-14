using System;
namespace Agiil.Domain.Tickets
{
  public class TicketSpecificationProviderFactory : IGetsTicketSpecificationProvider
  {
    readonly Func<TicketListRequest, TicketListSpecificationFromRequestAdapter> requestAdapterFactory;

    public IGetsTicketSpecification GetFromListRequest(TicketListRequest request)
      => requestAdapterFactory(request);

    public TicketSpecificationProviderFactory(
        Func<TicketListRequest,TicketListSpecificationFromRequestAdapter> requestAdapterFactory
      )
    {
      if(requestAdapterFactory == null)
        throw new ArgumentNullException(nameof(requestAdapterFactory));
      this.requestAdapterFactory = requestAdapterFactory;
    }
  }
}
