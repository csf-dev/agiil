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
            return;
        
          ConfigureRequestForClosedTickets(request);
        });
    }

    void ConfigureRequestForClosedTickets(TicketListRequest request)
    {
      // TODO: Write this implementation
      throw new NotImplementedException();

      //var searchNodes = request.CriteriaModel.Children;

      //var isOpenNodes = searchNodes.OfType<IsOpenNode>().ToList();
      //foreach(var node in isOpenNodes)
      //  searchNodes.Remove(node);

      //searchNodes.Add(new IsClosedNode());
    }
  }
}
