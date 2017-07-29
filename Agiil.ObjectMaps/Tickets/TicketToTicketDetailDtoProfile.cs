using System;
using System.Linq;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
  public class TicketToTicketDetailDtoProfile : Profile
  {
    readonly ITicketReferenceParser ticketReferenceParser;

    public TicketToTicketDetailDtoProfile()
    {
      CreateMap<Ticket,TicketDetailDto>()
        .ForMember(x => x.Id, o => o.ResolveUsing<IdentityValueResolver>())
        .ForMember(x => x.Creator, o => o.ResolveUsing(t => t.User.Username))
        .ForMember(x => x.Created, o => o.ResolveUsing(t => t.CreationTimestamp))
        .ForMember(x => x.Reference, o => o.ResolveUsing(t => ticketReferenceParser.CreateReference(t)))
        .AfterMap((ticket, dto) => {
          dto.Comments = dto.Comments.OrderBy(x => x.Timestamp).ToArray();
        })
        ;
    }

    public TicketToTicketDetailDtoProfile(ITicketReferenceParser ticketReferenceParser)
    {
      if(ticketReferenceParser == null)
        throw new ArgumentNullException(nameof(ticketReferenceParser));

      this.ticketReferenceParser = ticketReferenceParser;
    }
  }
}
