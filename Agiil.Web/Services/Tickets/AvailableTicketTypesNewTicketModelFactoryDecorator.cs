using System;
using System.Linq;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.Web.Services.Tickets
{
  public class AvailableTicketTypesNewTicketModelFactoryDecorator : IGetsNewTicketModel
  {
    readonly IGetsNewTicketModel wrapped;
    readonly ITicketTypeProvider ticketTypesProvider;
    readonly IMapper mapper;

    public NewTicketModel GetNewTicketModel(NewTicketSpecification spec)
    {
      var model = wrapped.GetNewTicketModel(spec);
      AddAvailableTicketTypes(model);
      return model;
    }


    void AddAvailableTicketTypes(IHasAvailableTicketTypes model)
    {
      model.AvailableTicketTypes = ticketTypesProvider.GetTicketTypes()
        .Select(mapper.Map<TicketTypeDto>)
        .ToList();
    }

    public AvailableTicketTypesNewTicketModelFactoryDecorator( IGetsNewTicketModel wrapped,
                                                               ITicketTypeProvider ticketTypesProvider,
                                                               IMapper mapper)
    {
      if(wrapped == null)
        throw new ArgumentNullException(nameof(wrapped));
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(ticketTypesProvider == null)
        throw new ArgumentNullException(nameof(ticketTypesProvider));
      this.wrapped = wrapped;
      this.ticketTypesProvider = ticketTypesProvider;
      this.mapper = mapper;
    }
  }
}
