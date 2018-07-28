using System;
namespace Agiil.Domain.TicketSearch
{
  public abstract class SearchVisitor : IVisitsTicketSearch
  {
    public virtual void Visit(ConstantValue node) {}
    public virtual void Visit(CriteriaGroup node) {}
    public virtual void Visit(CriteriaRoot node) {}
    public virtual void Visit(Criterion node) {}
    public virtual void Visit(Function node) {}
    public virtual void Visit(LogicalCriterion node) {}
    public virtual void Visit(Order node) {}
    public virtual void Visit(Ordering node) {}
    public virtual void Visit(PredicateAndValue node) {}
    public virtual void Visit(PredicateFunction node) {}
    public virtual void Visit(Search node) {}
    public virtual void Visit(Value node) {}
  }
}
