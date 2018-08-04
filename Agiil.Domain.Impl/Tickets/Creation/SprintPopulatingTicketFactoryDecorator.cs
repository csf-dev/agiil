using System;
using CSF.Data.Entities;

namespace Agiil.Domain.Tickets.Creation
{
  public class SprintPopulatingTicketFactoryDecorator : ICreatesTicket
  {
    readonly ICreatesTicket wrappedInstance;
    readonly IEntityData data;

    public Ticket CreateTicket(CreateTicketRequest request)
    {
      var ticket = wrappedInstance.CreateTicket(request);

      if(request.SprintIdentity != null)
        ticket.Sprint = data.Theorise(request.SprintIdentity);

      return ticket;
    }

    public SprintPopulatingTicketFactoryDecorator(ICreatesTicket wrappedInstance, IEntityData data)
    {
      if(wrappedInstance == null)
        throw new ArgumentNullException(nameof(wrappedInstance));
      if(data == null)
        throw new ArgumentNullException(nameof(data));

      this.wrappedInstance = wrappedInstance;
      this.data = data;
    }
  }
}
