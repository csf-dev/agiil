using System;
using System.Linq;
using Agiil.Domain.Tickets;
using Agiil.Domain.TicketSearch;
using Agiil.Web.Models.Tickets;
using AutoMapper;

namespace Agiil.ObjectMaps.Tickets
{
  public class AdHocTicketListSpecificationToTicketListRequestProfile : Profile
  {
    public AdHocTicketListSpecificationToTicketListRequestProfile(IGetsTicketListRequest defaultRequestFactory)
    {
      var map = CreateMap<AdHocTicketListSpecification,TicketListRequest>()
        .ConstructUsing(spec => defaultRequestFactory.GetRequest());

      map.ForAllMembers(opts => opts.Ignore());

      map.AfterMap((spec, request) => {
          if(spec == null || !spec.ShowClosedTickets)
            ConfigureRequestForOpenTickets(request);
          else
            ConfigureRequestForClosedTickets(request);
        });
    }

    void ConfigureRequestForClosedTickets(TicketListRequest request)
    {
      ConfigureRequestForOpenOrClosedTickets(request, WellKnownValue.Closed);
    }

    void ConfigureRequestForOpenTickets(TicketListRequest request)
    {
      ConfigureRequestForOpenOrClosedTickets(request, WellKnownValue.Open);
    }

    void ConfigureRequestForOpenOrClosedTickets(TicketListRequest request, string openOrClosed)
    {
      var criterion = new Criterion {
        ElementName = ElementName.Ticket,
        Test = new PredicateAndValue {
          PredicateText = PredicateName.Is,
          Value = new ConstantValue { Text = openOrClosed }
        }
      };

      request.SearchModel.CriteriaRoot = new CriteriaRoot();
      request.SearchModel.CriteriaRoot.Criteria.Add(criterion);
    }
  }
}
