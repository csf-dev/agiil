using System;
using Antlr4.Runtime.Tree;
using Context = Agiil.QueryLanguage.AgiilQueryParser.SearchContext;

namespace Agiil.QueryLanguage
{
  public class VisitorBasedSearchResultProvider : IGetsGetSearchResult
  {
    readonly Context context;
    readonly IAgiilQueryVisitor<Search> visitor;

    public GetSearchResult GetGetSearchResult()
    {
      if(context == null) return null;

      var search = visitor.Visit(context);
      return new GetSearchResult(search);
    }

    public VisitorBasedSearchResultProvider(IAgiilQueryVisitor<Search> visitor, Context context)
    {
      if(visitor == null)
        throw new ArgumentNullException(nameof(visitor));
      if(context == null)
        throw new ArgumentNullException(nameof(context));
      
      this.visitor = visitor;
      this.context = context;
    }
  }
}
