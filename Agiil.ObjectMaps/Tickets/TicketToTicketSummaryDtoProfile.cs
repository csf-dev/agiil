using System;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
  public class TicketToTicketSummaryDtoProfile : Profile
  {
    readonly ITicketReferenceParser ticketReferenceParser;

    public TicketToTicketSummaryDtoProfile()
    {
      CreateMap<Ticket,TicketSummaryDto>()
        .ForMember(x => x.Id, o => o.ResolveUsing<IdentityValueResolver>())
        .ForMember(x => x.Creator, o => o.ResolveUsing(t => t.User.Username))
        .ForMember(x => x.Created, o => o.ResolveUsing(t => t.CreationTimestamp))
        .ForMember(x => x.Reference, o => o.ResolveUsing(t => ticketReferenceParser.CreateReference(t)))
        ;
    }

    public TicketToTicketSummaryDtoProfile(ITicketReferenceParser ticketReferenceParser)
    {
      if(ticketReferenceParser == null)
        throw new ArgumentNullException(nameof(ticketReferenceParser));
      
      this.ticketReferenceParser = ticketReferenceParser;
    }
  }
}
