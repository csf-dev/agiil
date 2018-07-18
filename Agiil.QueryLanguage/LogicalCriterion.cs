using System;
using CSF;
namespace Agiil.QueryLanguage
{
  public abstract class LogicalCriterion
  {
    LogicalOperator logicalOperator;

    public LogicalOperator LogicalOperator
    {
      get { return logicalOperator; }
      set {
        logicalOperator = logicalOperator.IsDefinedValue()? value : LogicalOperator.And;
      }
    }
  }
}
