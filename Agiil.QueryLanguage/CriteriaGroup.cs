using System;
using System.Collections.Generic;

namespace Agiil.QueryLanguage
{
  public class CriteriaGroup : LogicalCriteriaGroup, IHasLogicalCriteriaGroups
  {
    IList<LogicalCriteriaGroup> criteriaGroups;

    public IList<LogicalCriteriaGroup> CriteriaGroups
    {
      get { return criteriaGroups; }
      set { criteriaGroups = value ?? new List<LogicalCriteriaGroup>(); }
    }

    public CriteriaGroup()
    {
      criteriaGroups = new List<LogicalCriteriaGroup>();
    }
  }
}
