using System;
using Agiil.Domain.Tickets;
using CSF.Data.Specifications;
using CSF;
using System.Linq;

namespace Agiil.Domain.TicketSearch
{
  public class SpecificationBuildingSearchVisitor : SearchVisitor, IGetsTicketSpecification
  {
    readonly IConvertsCriterionToSpecification criterionConverter;
    readonly Func<SpecificationBuildingSearchVisitor> recursiveVisitorFactory;
    ISpecificationExpression<Ticket> specBeingBuilt;

		public override void Visit(Search node)
		{
      if(node?.CriteriaRoot == null) return;
      Visit(node.CriteriaRoot);
		}

		public override void Visit(CriteriaRoot node)
		{
      VisitLogicalCriteriaProvider(node);
    }

		public override void Visit(LogicalCriterion node)
		{
      if(node == null) return;
      node.Accept(this);
		}

		public override void Visit(Criterion node)
		{
      var spec = criterionConverter.ConvertToSpecification(node);
      if(spec == null) return;

      specBeingBuilt = AddSpecification(spec, (node?.LogicalOperator) ?? default(LogicalOperator));
		}

		public override void Visit(CriteriaGroup node)
		{
      if(node?.Criteria == null || !node.Criteria.Any()) return;

      var recursiveVisitor = recursiveVisitorFactory();
      recursiveVisitor.VisitLogicalCriteriaProvider(node);
      var spec = recursiveVisitor.GetSpecification();

      if(spec == null) return;
      specBeingBuilt = AddSpecification(spec, node.LogicalOperator);
		}

		public void VisitLogicalCriteriaProvider(IHasLogicalCriteria node)
    {
      if(node?.Criteria == null || !node.Criteria.Any()) return;
      foreach(var logicalCriterion in node.Criteria)
      {
        Visit(logicalCriterion);
      }
    }

    public ISpecificationExpression<Ticket> GetSpecification()
      => specBeingBuilt ?? new DynamicSpecificationExpression<Ticket>(x => true);

    ISpecificationExpression<Ticket> AddSpecification(ISpecificationExpression<Ticket> toAdd,
                                                      LogicalOperator logicalOperator)
    {
      if(specBeingBuilt == null) return toAdd;
      logicalOperator.RequireDefinedValue(nameof(logicalOperator));

      switch(logicalOperator)
      {
      case LogicalOperator.Or:
        return specBeingBuilt.Or(toAdd);

      case LogicalOperator.And:
        return specBeingBuilt.And(toAdd);

      default:
        throw new NotSupportedException($"The {nameof(LogicalOperator)} must have a supported value.");
      }
    }

    public SpecificationBuildingSearchVisitor(IConvertsCriterionToSpecification criterionConverter,
                                              Func<SpecificationBuildingSearchVisitor> recursiveVisitorFactory)
    {
      if(recursiveVisitorFactory == null)
        throw new ArgumentNullException(nameof(recursiveVisitorFactory));
      if(criterionConverter == null)
        throw new ArgumentNullException(nameof(criterionConverter));
      this.criterionConverter = criterionConverter;
      this.recursiveVisitorFactory = recursiveVisitorFactory;
    }
  }
}
