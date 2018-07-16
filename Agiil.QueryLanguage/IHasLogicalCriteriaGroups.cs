using System;
using System.Collections.Generic;

namespace Agiil.QueryLanguage
{
  public interface IHasLogicalCriteriaGroups
  {
    IList<LogicalCriteriaGroup> CriteriaGroups { get; set; }
  }
}
