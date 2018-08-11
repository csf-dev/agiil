using System;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.Web.Services.Tickets
{
  public class MappingEditTicketModelFactory : IGetsEditTicketModel
  {
    readonly IMapper mapper;

    public EditTicketModel GetEditTicketModel(Ticket ticket)
    {
      if(ticket == null)
        throw new ArgumentNullException(nameof(ticket));
      
      return new EditTicketModel {
        Ticket = mapper.Map<TicketDetailDto>(ticket),
      };
    }

    public MappingEditTicketModelFactory(IMapper mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      this.mapper = mapper;
    }
  }
}
