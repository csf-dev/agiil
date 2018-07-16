using System;
using System.Collections.Generic;

namespace Agiil.QueryLanguage
{
  public class Criteria : IHasLogicalCriteriaGroups
  {
    IList<LogicalCriteriaGroup> criteriaGroups;

    public IList<LogicalCriteriaGroup> CriteriaGroups
    {
      get { return criteriaGroups; }
      set { criteriaGroups = value ?? new List<LogicalCriteriaGroup>(); }
    }

    public Criteria()
    {
      criteriaGroups = new List<LogicalCriteriaGroup>();
    }
  }
}
