using System;
using System.Collections.Generic;

namespace Agiil.QueryLanguage
{
  public class CriteriaRoot : IHasLogicalCriteria
  {
    IList<LogicalCriterion> criteriaGroups;

    public IList<LogicalCriterion> Criteria
    {
      get { return criteriaGroups; }
      set { criteriaGroups = value ?? new List<LogicalCriterion>(); }
    }

    public CriteriaRoot()
    {
      criteriaGroups = new List<LogicalCriterion>();
    }
  }
}
