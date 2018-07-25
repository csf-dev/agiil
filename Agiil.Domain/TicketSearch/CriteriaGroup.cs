using System;
using System.Collections.Generic;

namespace Agiil.Domain.TicketSearch
{
  public class CriteriaGroup : LogicalCriterion, IHasLogicalCriteria
  {
    IList<LogicalCriterion> criteriaGroups;

    public IList<LogicalCriterion> Criteria
    {
      get { return criteriaGroups; }
      set { criteriaGroups = value ?? new List<LogicalCriterion>(); }
    }

    public override void Accept(IVisitsTicketSearch visitor) { visitor?.Visit(this); }

    public CriteriaGroup()
    {
      criteriaGroups = new List<LogicalCriterion>();
    }
  }
}
