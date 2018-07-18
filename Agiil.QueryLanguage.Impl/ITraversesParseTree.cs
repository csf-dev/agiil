using System;
using Antlr4.Runtime.Tree;

namespace Agiil.QueryLanguage
{
  public interface ITraversesParseTree
  {
    void Walk (IParseTreeListener listener, IParseTree t);
  }
}
