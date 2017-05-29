using System;

using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;
using CSF.Entities;

namespace Agiil.ObjectMaps.Tickets
{
  public class CreateTicketResponseToNewTicketResponseProfile : Profile
  {
    public CreateTicketResponseToNewTicketResponseProfile()
    {
      CreateMap<CreateTicketResponse,NewTicketResponse>()
        .ForMember(x => x.TicketIdentity, opts => opts.ResolveUsing(x => x?.Ticket?.GetIdentity()))
        ;
    }
  }
}
