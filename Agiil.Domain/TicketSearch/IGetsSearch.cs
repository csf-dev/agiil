using System;
namespace Agiil.Domain.TicketSearch
{
  public interface IGetsSearch
  {
    GetSearchResult GetSearch(string text);
  }
}
