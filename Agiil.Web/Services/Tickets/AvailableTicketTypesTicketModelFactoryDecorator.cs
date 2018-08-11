using System;
using System.Linq;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.Web.Services.Tickets
{
  public class AvailableTicketTypesTicketModelFactoryDecorator : IGetsEditTicketModel
  {
    readonly IGetsEditTicketModel wrapped;
    readonly ITicketTypeProvider ticketTypesProvider;
    readonly IMapper mapper;

    public EditTicketModel GetEditTicketModel(Ticket ticket)
    {
      var model = wrapped.GetEditTicketModel(ticket);
      AddAvailableTicketTypes(model);
      return model;
    }


    void AddAvailableTicketTypes(IHasAvailableTicketTypes model)
    {
      model.AvailableTicketTypes = ticketTypesProvider.GetTicketTypes()
        .Select(mapper.Map<TicketTypeDto>)
        .ToList();
    }

    public AvailableTicketTypesTicketModelFactoryDecorator(IGetsEditTicketModel wrapped,
                                                               ITicketTypeProvider ticketTypesProvider,
                                                               IMapper mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(ticketTypesProvider == null)
        throw new ArgumentNullException(nameof(ticketTypesProvider));
      if(wrapped == null)
        throw new ArgumentNullException(nameof(wrapped));
      this.wrapped = wrapped;
      this.ticketTypesProvider = ticketTypesProvider;
      this.mapper = mapper;
    }
  }
}
