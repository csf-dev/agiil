using System;
namespace Agiil.Domain.TicketSearch
{
  public interface IVisitsTicketSearch
  {
    void Visit(ConstantValue node);
    void Visit(CriteriaGroup node);
    void Visit(CriteriaRoot node);
    void Visit(Criterion node);
    void Visit(Function node);
    void Visit(LogicalCriterion node);
    void Visit(Order node);
    void Visit(Ordering node);
    void Visit(PredicateAndValue node);
    void Visit(PredicateFunction node);
    void Visit(Search node);
    void Visit(Value node);
  }
}
