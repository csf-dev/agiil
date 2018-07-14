using System;
using Agiil.Domain.TicketSearch;

namespace Agiil.Domain.Tickets
{
  public class TicketListRequest
  {
    public SearchModel CriteriaModel { get; }

    // In the future this will also have:
    // * An ordering model
    // * A model indicating which columns we wish to display in the output

    public TicketListRequest()
    {
      CriteriaModel = new SearchModel();
    }
  }
}
