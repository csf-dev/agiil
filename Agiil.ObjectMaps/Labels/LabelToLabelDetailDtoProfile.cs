using System;
using Agiil.Domain.Labels;
using Agiil.Web.Models.Labels;
using AutoMapper;

namespace Agiil.ObjectMaps.Labels
{
  public class LabelToLabelDetailDtoProfile : Profile
  {
    public LabelToLabelDetailDtoProfile(IGetsTicketsWithLabel ticketProvider)
    {
      CreateMap<Label,LabelDetailDto>()
        .ForMember(x => x.OpenTickets, opts => opts.ResolveUsing(label => ticketProvider.GetAllOpenTickets(label)))
        .ForMember(x => x.ClosedTickets, opts => opts.ResolveUsing(label => ticketProvider.GetAllClosedTickets(label)))
        ;
    }
  }
}
