using System;
using System.Collections.Generic;

namespace Agiil.Domain.TicketSearch
{
  public interface IHasLogicalCriteria
  {
    IList<LogicalCriterion> Criteria { get; set; }
  }
}
