using Antlr4.Runtime.Tree;

namespace Agiil.QueryLanguage
{
  public class AntlrParseTreeWalkerTraverser : ITraversesParseTree
  {
    public void Walk(IParseTreeListener listener, IParseTree t)
    {
      ParseTreeWalker.Default.Walk(listener, t);
    }
  }
}
