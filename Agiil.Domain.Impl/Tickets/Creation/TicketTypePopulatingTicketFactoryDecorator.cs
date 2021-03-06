﻿using System;
using CSF.ORM;

namespace Agiil.Domain.Tickets.Creation
{
  public class TicketTypePopulatingTicketFactoryDecorator : ICreatesTicket
  {
    readonly ICreatesTicket wrappedInstance;
    readonly IEntityData data;

    public Ticket CreateTicket(CreateTicketRequest request)
    {
      var ticket = wrappedInstance.CreateTicket(request);

      ticket.Type = data.Theorise(request.TicketTypeIdentity);

      return ticket;
    }

    public TicketTypePopulatingTicketFactoryDecorator(ICreatesTicket wrappedInstance, IEntityData data)
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
