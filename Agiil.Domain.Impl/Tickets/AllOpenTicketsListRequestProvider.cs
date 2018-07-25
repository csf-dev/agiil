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
        ElementName = ElementName.Ticket,
        Test = new PredicateAndValue {
          PredicateText = PredicateName.Is,
          Value = new ConstantValue { Text = WellKnownValue.Open },
        },
      };
      list.SearchModel.CriteriaRoot.Criteria.Add(ticketIsOpenCriterion);
      return list;
    }
  }
}
