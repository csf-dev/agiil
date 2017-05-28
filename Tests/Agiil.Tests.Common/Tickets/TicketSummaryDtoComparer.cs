using System;
using System.Collections;
using System.Collections.Generic;
using Agiil.Web.Models.Tickets;

namespace Agiil.Tests.Tickets
{
  public class TicketSummaryDtoComparer : TestComparerBase<TicketSummaryDto>
  {
    protected override bool AreNonNullInstancesEqual(TicketSummaryDto x, TicketSummaryDto y)
    {
      return (x.Title == y.Title
              && x.Creator == y.Creator
              && x.Created == y.Created);
    }

    protected override int CompareNonNullInstances(TicketSummaryDto first, TicketSummaryDto second)
    {
      return (first.Id > second.Id)? 1 : -1;
    }

    protected override int GetHashCodeForNonNullInstance(TicketSummaryDto obj)
    {
      return ((obj?.Title?? String.Empty).GetHashCode()
              ^ (obj?.Creator?? String.Empty).GetHashCode()
              ^ (obj?.Created?? DateTime.MinValue).GetHashCode());
    }
  }
}
