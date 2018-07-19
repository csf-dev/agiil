using System;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Agiil.Domain.TicketSearch;

namespace Agiil.QueryLanguage.Visitors
{
  public class LogicalCriteriaVisitor : AgiilQueryBaseVisitor<IList<LogicalCriterion>>
  {
    readonly IAgiilQueryVisitor<Criterion> criterionVisitor;
    readonly IAgiilQueryVisitor<CriteriaGroup> criteriaGroupVisitor;
    readonly IAgiilQueryVisitor<LogicalOperator> operatorVisitor;

    public override IList<LogicalCriterion> VisitCriteria([NotNull] AgiilQueryParser.CriteriaContext context)
    {
      return GetLogicalCriteriaGroups(context.logicalcriteriagroups());
    }

		public override IList<LogicalCriterion> VisitCriteriagroup([NotNull] AgiilQueryParser.CriteriagroupContext context)
		{
      return GetLogicalCriteriaGroups(context.logicalcriteriagroups());
		}

    protected override bool ShouldVisitNextChild(IRuleNode node, IList<LogicalCriterion> currentResult) => false;

    IList<LogicalCriterion> GetLogicalCriteriaGroups(AgiilQueryParser.LogicalcriteriagroupsContext context)
    {
      var subContexts = context.children;

      var output = new List<LogicalCriterion>();
      var currentOperator = default(LogicalOperator);

      foreach(var child in subContexts)
      {
        var logicalCriterion = GetLogicalCriterion(child, currentOperator);
        if(logicalCriterion != null)
        {
          output.Add(logicalCriterion);
          currentOperator = default(LogicalOperator);
          continue;
        }

        currentOperator = operatorVisitor.Visit(child);
      }

      return output;
    }

    LogicalCriterion GetLogicalCriterion(IParseTree node, LogicalOperator logicalOperator)
    {
      var output = GetCriterion(node) ?? GetCriteriaGroup(node);
      if(output == null) return null;
      output.LogicalOperator = logicalOperator;

      return output;
    }

    LogicalCriterion GetCriterion(IParseTree node) => criterionVisitor.Visit(node);

    LogicalCriterion GetCriteriaGroup(IParseTree node) => criteriaGroupVisitor.Visit(node);

    public LogicalCriteriaVisitor(IAgiilQueryVisitor<Criterion> criterionVisitor,
                                  IAgiilQueryVisitor<CriteriaGroup> criteriaGroupVisitor,
                                  IAgiilQueryVisitor<LogicalOperator> operatorVisitor)
    {
      if(criteriaGroupVisitor == null)
        throw new ArgumentNullException(nameof(criteriaGroupVisitor));
      if(criterionVisitor == null)
        throw new ArgumentNullException(nameof(criterionVisitor));
      if(operatorVisitor == null)
        throw new ArgumentNullException(nameof(operatorVisitor));
      this.criterionVisitor = criterionVisitor;
      this.criteriaGroupVisitor = criteriaGroupVisitor;
      this.operatorVisitor = operatorVisitor;
    }
	}
}
