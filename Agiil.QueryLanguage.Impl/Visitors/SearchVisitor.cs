using System;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace Agiil.QueryLanguage.Visitors
{
  public class SearchVisitor : AgiilQueryBaseVisitor<Search>
  {
    readonly IAgiilQueryVisitor<CriteriaRoot> criteriaVisitor;
    readonly IAgiilQueryVisitor<Ordering> orderVisitor;

		public override Search VisitSearch([NotNull] AgiilQueryParser.SearchContext context)
		{
      var criteriaContext = context.criteria();
      var orderContext = context.orders();

      var output = new Search();

      if(criteriaContext != null)
        output.Criteria = criteriaVisitor.Visit(criteriaContext);

      if(orderContext != null)
        output.Ordering = orderVisitor.Visit(orderContext);

      return output;
		}

		protected override bool ShouldVisitNextChild(IRuleNode node, Search currentResult) => false;

		public SearchVisitor(IAgiilQueryVisitor<CriteriaRoot> criteriaVisitor,
                                 IAgiilQueryVisitor<Ordering> orderVisitor)
    {
      if(orderVisitor == null)
        throw new ArgumentNullException(nameof(orderVisitor));
      if(criteriaVisitor == null)
        throw new ArgumentNullException(nameof(criteriaVisitor));
      
      this.criteriaVisitor = criteriaVisitor;
      this.orderVisitor = orderVisitor;
    }
	}
}
