using System;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Agiil.QueryLanguage.Visitors
{
  public class CriteriaRootVisitor : AgiilQueryBaseVisitor<CriteriaRoot>
  {
    readonly IAgiilQueryVisitor<IList<LogicalCriterion>> logicalCriteriaVisitor;

    public override CriteriaRoot VisitCriteria([NotNull] AgiilQueryParser.CriteriaContext context)
		{
      return new CriteriaRoot {
        Criteria = logicalCriteriaVisitor.Visit(context)
      };
		}

    protected override bool ShouldVisitNextChild(IRuleNode node, CriteriaRoot currentResult) => false;

    public CriteriaRootVisitor(IAgiilQueryVisitor<IList<LogicalCriterion>> logicalCriteriaVisitor)
    {
      if(logicalCriteriaVisitor == null)
        throw new ArgumentNullException(nameof(logicalCriteriaVisitor));
      
      this.logicalCriteriaVisitor = logicalCriteriaVisitor;
    }
	}
}
