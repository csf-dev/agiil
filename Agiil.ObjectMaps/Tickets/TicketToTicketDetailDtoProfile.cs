using System;
using System.Linq;
using Agiil.Domain.Labels;
using Agiil.Domain.Tickets;
using Agiil.ObjectMaps.Resolvers;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
  public class TicketToTicketDetailDtoProfile : Profile
  {
    public TicketToTicketDetailDtoProfile(TicketReferenceStringResolver ticketRefResolver,
                                          MarkdownToHtmlResolver markdownResolver,
                                          IParsesLabelNames labelNameParser)
    {
      CreateMap<Ticket,TicketDetailDto>()
        .ForMember(x => x.Id, o => o.ResolveUsing<IdentityValueResolver>())
        .ForMember(x => x.Creator, o => o.ResolveUsing(t => t.User.Username))
        .ForMember(x => x.Created, o => o.ResolveUsing(t => t.CreationTimestamp))
        .ForMember(x => x.Reference, o => o.ResolveUsing(ticketRefResolver))
        .ForMember(x => x.HtmlDescription, o => o.ResolveUsing(markdownResolver, m => m.Description))
        .ForMember(x => x.TypeName, o => o.ResolveUsing(t => t.Type?.Name))
        .ForMember(x => x.CommaSeparatedLabelNames,
                   o => o.ResolveUsing(t => labelNameParser.GetCommaSeparatedLabelNames(t.Labels)))
        .AfterMap((ticket, dto) => {
          dto.Comments = dto.Comments.OrderBy(x => x.Timestamp).ToArray();
        })
        ;
    }
  }
}
