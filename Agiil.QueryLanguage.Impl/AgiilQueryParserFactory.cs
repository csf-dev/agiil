using System;
using Antlr4.Runtime;

namespace Agiil.QueryLanguage
{
  public class AgiilQueryParserFactory : IGetsSearchContextProvider
  {
    public IGetsSearchContext GetSearchContextProvider(string text)
    {
      var antlrStream = new AntlrInputStream(text);
      var lexer = new AgiilQueryLexer(antlrStream);
      var tokenStream = new CommonTokenStream(lexer);

      return new AgiilQueryParser(tokenStream) {
        BuildParseTree = true,
      };
    }
  }
}
