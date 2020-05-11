using System;
using Agiil.Domain.Labels;
using Agiil.ObjectMaps.Resolvers;
using Agiil.Web.Models.Labels;
using AutoMapper;

namespace Agiil.ObjectMaps.Labels
{
  public class LabelToLabelDetailDtoProfile : Profile
  {
    public LabelToLabelDetailDtoProfile()
    {
      CreateMap<Label,LabelDetailDto>()
        .ForMember(x => x.OpenTickets, opts => opts.ResolveUsing<OpenTicketsForLabelResolver>())
        .ForMember(x => x.ClosedTickets, opts => opts.ResolveUsing<ClosedTicketsForLabelResolver>())
        ;
    }
  }
}
