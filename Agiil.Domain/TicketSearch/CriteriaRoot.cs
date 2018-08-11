using System;
using System.Collections.Generic;

namespace Agiil.Domain.TicketSearch
{
  public class CriteriaRoot : IHasLogicalCriteria
  {
    IList<LogicalCriterion> criteriaGroups;

    public IList<LogicalCriterion> Criteria
    {
      get { return criteriaGroups; }
      set { criteriaGroups = value ?? new List<LogicalCriterion>(); }
    }

    public void Accept(IVisitsTicketSearch visitor) { visitor?.Visit(this); }

    public CriteriaRoot()
    {
      criteriaGroups = new List<LogicalCriterion>();
    }
  }
}
