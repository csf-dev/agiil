using System;
namespace Agiil.QueryLanguage
{
  public class GetSearchResult
  {
    public Search Search { get; }

    public GetSearchResult() : this(new Search()) {}

    public GetSearchResult(Search search)
    {
      if(search == null)
        throw new ArgumentNullException(nameof(search));

      Search = search;
    }
  }
}
