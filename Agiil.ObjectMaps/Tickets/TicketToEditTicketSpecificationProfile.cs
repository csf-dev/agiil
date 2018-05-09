using System;
using Agiil.Domain.Labels;
using Agiil.Domain.Tickets;
using Agiil.Web.Models.Tickets;
using AutoMapper;
using CSF.Entities;

namespace Agiil.ObjectMaps.Tickets
{
  public class TicketToEditTicketSpecificationProfile : Profile
  {
    public TicketToEditTicketSpecificationProfile(IParsesLabelNames labelNameParser)
    {
      CreateMap<Ticket,EditTicketSpecification>()
        .ForMember(x => x.Identity, opts => opts.ResolveUsing(x => x.GetIdentity()))
        .ForMember(x => x.SprintIdentity, opts => opts.ResolveUsing(x => x.Sprint?.GetIdentity()))
        .ForMember(x => x.CommaSeparatedLabelNames,
                   o => o.ResolveUsing(t => labelNameParser.GetCommaSeparatedLabelNames(t.Labels)))
        ;
    }
  }
}
