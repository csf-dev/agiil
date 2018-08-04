using System;
using AutoMapper;

namespace Agiil.Domain.Tickets.Editing
{
  public class AutomapperBasedTicketEditor : IEditsTicket
  {
    readonly IMapper mapper;

    public void Edit(Ticket ticket, EditTicketRequest request)
    {
      mapper.Map(request, ticket);
    }

    public AutomapperBasedTicketEditor(IMapper mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      this.mapper = mapper;
    }
  }
}
