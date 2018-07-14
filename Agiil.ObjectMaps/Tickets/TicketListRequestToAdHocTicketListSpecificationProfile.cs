using System;
using System.Linq;
using Agiil.Domain.Tickets;
using Agiil.Domain.TicketSearch;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
  public class TicketListRequestToTicketListModelProfile : Profile
  {
    public TicketListRequestToTicketListModelProfile()
    {
      CreateMap<TicketListRequest,TicketListModel>()
        .ForMember(x => x.ShowingClosedTickets, opts => opts.ResolveUsing(GetShowClosedTickets))
        .ForAllOtherMembers(opts => opts.Ignore());
    }

    bool GetShowClosedTickets(TicketListRequest request)
    {
      if(request?.CriteriaModel == null)
        return false;

      return request.CriteriaModel.Children.OfType<IsClosedNode>().Any();
    }
  }
}
