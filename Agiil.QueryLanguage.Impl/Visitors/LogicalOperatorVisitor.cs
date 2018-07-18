using System;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Agiil.QueryLanguage.Visitors
{
  public class LogicalOperatorVisitor : AgiilQueryBaseVisitor<LogicalOperator>
  {
		public override LogicalOperator VisitLogicaloperator([NotNull] AgiilQueryParser.LogicaloperatorContext context)
		{
      if(context.AND() != null)
        return LogicalOperator.And;

      if(context.OR() != null)
        return LogicalOperator.Or;

      return default(LogicalOperator);
		}

		protected override bool ShouldVisitNextChild(IRuleNode node, LogicalOperator currentResult) => false;
	}
}
