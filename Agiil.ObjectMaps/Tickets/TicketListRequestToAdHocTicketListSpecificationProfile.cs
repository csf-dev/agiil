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
      var criteria = request.SearchModel
                            .CriteriaRoot
                            .Criteria
                            .OfType<Criterion>()
                            .Where(x => x.LogicalOperator == LogicalOperator.And)
                            .Where(x => x.Test is PredicateAndValue);

      return criteria.Any(x => x.ElementName == ElementName.Ticket
                               && ((PredicateAndValue) x.Test).PredicateText == PredicateName.Is
                               && (((PredicateAndValue) x.Test).Value as ConstantValue)?.Text == WellKnownValue.Closed);
    }
  }
}
