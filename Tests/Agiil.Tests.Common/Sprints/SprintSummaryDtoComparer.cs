using System;
using System.Collections;
using System.Collections.Generic;
using Agiil.Web.Models.Sprints;

namespace Agiil.Tests.Sprints
{
  public class SprintSummaryDtoComparer : TestComparerBase<SprintSummaryDto>
  {
    protected override bool AreNonNullInstancesEqual(SprintSummaryDto x, SprintSummaryDto y)
    {
      return (x.Id == y.Id
              && x.Name == y.Name
              && x.StartDate == y.StartDate
              && x.EndDate == y.EndDate);
    }

    protected override int CompareNonNullInstances(SprintSummaryDto first, SprintSummaryDto second)
    {
      return (first.Id > second.Id)? 1 : -1;
    }

    protected override int GetHashCodeForNonNullInstance(SprintSummaryDto obj)
    {
      return (obj.Id.GetHashCode()
              ^ (obj.Name ?? String.Empty).GetHashCode()
              ^ (obj.StartDate ?? DateTime.MinValue).GetHashCode()
              ^ (obj.EndDate ?? DateTime.MinValue).GetHashCode());
    }
  }
}
