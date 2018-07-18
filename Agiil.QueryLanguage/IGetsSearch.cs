using System;
namespace Agiil.QueryLanguage
{
  public interface IGetsSearch
  {
    GetSearchResult GetSearch(string text);
  }
}
