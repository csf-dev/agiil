using System;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Agiil.QueryLanguage.Visitors
{
  public class CriterionVisitor : AgiilQueryBaseVisitor<Criterion>
  {
    readonly IAgiilQueryVisitor<Function> functionVisitor;
    readonly IAgiilQueryVisitor<Value> valueVisitor;

		public override Criterion VisitCriterionorgroup([NotNull] AgiilQueryParser.CriterionorgroupContext context)
		{
      return VisitCriterion(context.criterion());
		}

		public override Criterion VisitCriterion([NotNull] AgiilQueryParser.CriterionContext context)
		{
      var name = context.element().GetText();
      var predicateDescription = GetPredicateDescription(context.elementtest());

      return new Criterion {
        ElementName = name,
        Test = predicateDescription
      };
		}

    protected override bool ShouldVisitNextChild(IRuleNode node, Criterion currentResult) => false;

    IDescribesPredicate GetPredicateDescription(AgiilQueryParser.ElementtestContext context)
    {
      return GetPredicateFunction(context) ?? GetPredicateAndValue(context);
    }

    IDescribesPredicate GetPredicateFunction(AgiilQueryParser.ElementtestContext context)
    {
      return functionVisitor.Visit(context) as PredicateFunction;
    }

    IDescribesPredicate GetPredicateAndValue(AgiilQueryParser.ElementtestContext context)
    {
      var predicate = context.predicate().GetText();
      var value = valueVisitor.Visit(context.value());

      return new PredicateAndValue {
        PredicateText = predicate,
        Value = value,
      };
    }

    public CriterionVisitor(IAgiilQueryVisitor<Function> functionVisitor,
                            IAgiilQueryVisitor<Value> valueVisitor)
    {
      if(valueVisitor == null)
        throw new ArgumentNullException(nameof(valueVisitor));
      if(functionVisitor == null)
        throw new ArgumentNullException(nameof(functionVisitor));
      this.functionVisitor = functionVisitor;
      this.valueVisitor = valueVisitor;
    }
  }
}
