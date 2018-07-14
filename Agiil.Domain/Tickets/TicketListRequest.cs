using System;
using Agiil.Domain.TicketSearch;

namespace Agiil.Domain.Tickets
{
  public class TicketListRequest
  {
    public SearchModel CriteriaModel { get; }

    public TicketListRequest()
    {
      CriteriaModel = new SearchModel();
    }
  }
}
