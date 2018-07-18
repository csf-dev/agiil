using System;
using System.Collections.Generic;

namespace Agiil.QueryLanguage
{
  public interface IHasLogicalCriteria
  {
    IList<LogicalCriterion> Criteria { get; set; }
  }
}
