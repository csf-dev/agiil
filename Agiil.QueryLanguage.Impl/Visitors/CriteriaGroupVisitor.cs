using System;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Agiil.QueryLanguage.Visitors
{
  public class CriteriaGroupVisitor : AgiilQueryBaseVisitor<CriteriaGroup>
  {
    readonly Lazy<IAgiilQueryVisitor<IList<LogicalCriterion>>> logicalCriteriaVisitor;

    public override CriteriaGroup VisitCriterionorgroup([NotNull] AgiilQueryParser.CriterionorgroupContext context)
    {
      return VisitCriteriagroup(context.criteriagroup());
    }

		public override CriteriaGroup VisitCriteriagroup([NotNull] AgiilQueryParser.CriteriagroupContext context)
		{
      return new CriteriaGroup {
        Criteria = logicalCriteriaVisitor.Value.Visit(context),
      };
		}

		protected override bool ShouldVisitNextChild(IRuleNode node, CriteriaGroup currentResult) => false;

    public CriteriaGroupVisitor(Lazy<IAgiilQueryVisitor<IList<LogicalCriterion>>> logicalCriteriaVisitor)
    {
      if(logicalCriteriaVisitor == null)
        throw new ArgumentNullException(nameof(logicalCriteriaVisitor));

      this.logicalCriteriaVisitor = logicalCriteriaVisitor;
    }
  }
}
