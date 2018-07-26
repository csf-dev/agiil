using System;
using System.Collections.Generic;
using Agiil.Domain.TicketSearch;

namespace Agiil.Domain.Tickets
{
  public class TicketListerFromAgiilQueryAdapter : IGetsListOfTicketsFromAgiilQuery
  {
    readonly IGetsListOfTickets lister;
    readonly IGetsSearch searchParser;

    public IReadOnlyList<Ticket> GetTickets(string agiilQueryString)
    {
      var request = GetRequest(agiilQueryString);
      return lister.GetTickets(request);
    }

    TicketListRequest GetRequest(string agiilQueryString)
    {
      var search = searchParser.GetSearch(agiilQueryString);
      return new TicketListRequest {
        SearchModel = search.Search,
      };
    }

    public TicketListerFromAgiilQueryAdapter(IGetsListOfTickets lister, IGetsSearch searchParser)
    {
      if(searchParser == null)
        throw new ArgumentNullException(nameof(searchParser));
      if(lister == null)
        throw new ArgumentNullException(nameof(lister));
      this.lister = lister;
      this.searchParser = searchParser;
    }
  }
}
