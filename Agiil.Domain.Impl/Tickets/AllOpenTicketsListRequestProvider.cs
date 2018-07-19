using System;
using Agiil.Domain.TicketSearch;

namespace Agiil.Domain.Tickets
{
  public class AllOpenTicketsListRequestProvider : IGetsTicketListRequest
  {
    public TicketListRequest GetRequest()
    {
      var list = new TicketListRequest();
      var ticketIsOpenCriterion = new Criterion {
        ElementName = "state",
        Test = new PredicateAndValue {
          PredicateText = "=",
          Value = new ConstantValue { Text = "open" },
        },
      };
      list.SearchModel.CriteriaRoot.Criteria.Add(ticketIsOpenCriterion);
      return list;
    }
  }
}
