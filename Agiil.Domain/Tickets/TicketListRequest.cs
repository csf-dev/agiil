using System;
using Agiil.Domain.TicketSearch;

namespace Agiil.Domain.Tickets
{
  public class TicketListRequest
  {
    Search searchModel;

    public Search SearchModel
    {
      get { return searchModel; }
      set { searchModel = value ?? new Search(); }
    }

    public TicketListRequest()
    {
      searchModel = new Search();
    }
  }
}
