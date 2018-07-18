using System;
using Antlr4.Runtime.Tree;

namespace Agiil.QueryLanguage.Visitors
{
  public class OrderingCreatingVisitor : AgiilQueryBaseVisitor<Ordering>
  {
    protected override bool ShouldVisitNextChild(IRuleNode node, Ordering currentResult) => false;
  }
}
