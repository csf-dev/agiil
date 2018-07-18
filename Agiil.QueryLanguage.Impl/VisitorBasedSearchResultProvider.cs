using System;
using Antlr4.Runtime.Tree;

namespace Agiil.QueryLanguage
{
  public class VisitorBasedSearchResultProvider : IGetsGetSearchResult
  {
    readonly IParseTree parseTree;
    readonly IAgiilQueryVisitor<Search> visitor;

    public GetSearchResult GetGetSearchResult()
    {
      var search = visitor.Visit(parseTree);
      return new GetSearchResult(search);
    }

    public VisitorBasedSearchResultProvider(IAgiilQueryVisitor<Search> visitor, IParseTree parseTree)
    {
      if(visitor == null)
        throw new ArgumentNullException(nameof(visitor));
      if(parseTree == null)
        throw new ArgumentNullException(nameof(parseTree));
      
      this.visitor = visitor;
      this.parseTree = parseTree;
    }
  }
}
