using System;
using System.Collections;
using System.Collections.Generic;
using Agiil.Web.Models;
using Agiil.Web.Models.Tickets;

namespace Agiil.Tests.Tickets
{
  public class TicketDetailDtoComparer : TestComparerBase<TicketDetailDto>
  {
    protected override bool AreNonNullInstancesEqual(TicketDetailDto x, TicketDetailDto y)
    {
      return (x.Id == y.Id
              && x.Title == y.Title
              && x.Description == y.Description
              && x.Creator == y.Creator
              && x.Created == y.Created);
    }

    protected override int CompareNonNullInstances(TicketDetailDto first, TicketDetailDto second)
    {
      return (first.Id > second.Id)? 1 : -1;
    }

    protected override int GetHashCodeForNonNullInstance(TicketDetailDto obj)
    {
      return (obj.Id.GetHashCode()
              ^ (obj?.Title?? String.Empty).GetHashCode()
              ^ (obj?.Description?? String.Empty).GetHashCode()
              ^ (obj?.Creator?? String.Empty).GetHashCode()
              ^ (obj?.Created?? DateTime.MinValue).GetHashCode());
    }
  }
}
