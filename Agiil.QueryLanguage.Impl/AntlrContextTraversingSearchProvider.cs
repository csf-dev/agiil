using System;
using Context = Agiil.QueryLanguage.AgiilQueryParser.SearchContext;

namespace Agiil.QueryLanguage
{
  public class AntlrContextTraversingSearchProvider : IGetsSearch
  {
    readonly IGetsSearchContextProvider contextProviderFactory;
    readonly Func<Context,IGetsGetSearchResult> searchResultProviderFactory;

    public GetSearchResult GetSearch(string text)
    {
      var contextProvider = contextProviderFactory.GetSearchContextProvider(text);
      var context = contextProvider.GetSearchContext();
      var searchResultProvider = searchResultProviderFactory(context);
      return searchResultProvider.GetGetSearchResult();
    }

    public AntlrContextTraversingSearchProvider(IGetsSearchContextProvider contextProviderFactory,
                                                Func<Context,IGetsGetSearchResult> searchResultProviderFactory)
    {
      if(searchResultProviderFactory == null)
        throw new ArgumentNullException(nameof(searchResultProviderFactory));
      if(contextProviderFactory == null)
        throw new ArgumentNullException(nameof(contextProviderFactory));
      
      this.contextProviderFactory = contextProviderFactory;
      this.searchResultProviderFactory = searchResultProviderFactory;
    }
  }
}
