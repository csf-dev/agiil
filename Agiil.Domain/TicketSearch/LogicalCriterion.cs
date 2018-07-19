using System;
using CSF;
namespace Agiil.Domain.TicketSearch
{
  public abstract class LogicalCriterion
  {
    LogicalOperator logicalOperator;

    public LogicalOperator LogicalOperator
    {
      get { return logicalOperator; }
      set {
        logicalOperator = logicalOperator.IsDefinedValue()? value : default(LogicalOperator);
      }
    }
  }
}
