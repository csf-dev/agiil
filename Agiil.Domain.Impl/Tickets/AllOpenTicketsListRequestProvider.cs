using System;
using Agiil.Domain.TicketSearch;

namespace Agiil.Domain.Tickets
{
  public class AllOpenTicketsListRequestProvider : IGetsTicketListRequest
  {
    public TicketListRequest GetRequest()
    {
      var list = new TicketListRequest { CriteriaModel = new SearchModel(), };
      list.CriteriaModel.Children.Add(new IsOpenNode());
      return list;
    }
  }
}
