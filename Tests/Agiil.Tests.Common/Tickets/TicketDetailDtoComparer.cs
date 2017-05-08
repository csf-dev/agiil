using System;
using System.Collections;
using System.Collections.Generic;
using Agiil.Web.Models;

namespace Agiil.Tests.Tickets
{
  public class TicketDetailDtoComparer : IEqualityComparer<TicketDetailDto>, IComparer
  {
    public int Compare(object x, object y)
    {
      if(ReferenceEquals(x, y))
        return 0;

      TicketSummaryDto
      first = x as TicketSummaryDto,
      second = y as TicketSummaryDto;

      if(ReferenceEquals(first, null))
        return -1;
      if(ReferenceEquals(second, null))
        return 1;

      if(Equals(first, second))
        return 0;

      return (first.Id > second.Id)? 1 : -1;
    }

    public virtual bool Equals(TicketDetailDto x, TicketDetailDto y)
    {
      if(ReferenceEquals(x, y))
        return true;
      if(ReferenceEquals(x, null))
        return false;
      if(ReferenceEquals(y, null))
        return false;

      return (x.Id == y.Id
              && x.Title == y.Title
              && x.Description == y.Description
              && x.Creator == y.Creator
              && x.Created == y.Created);
    }

    public virtual int GetHashCode(TicketDetailDto obj)
    {
      if(ReferenceEquals(obj, null))
        return 0;

      return (obj.Id.GetHashCode()
              ^ (obj?.Title?? String.Empty).GetHashCode()
              ^ (obj?.Description?? String.Empty).GetHashCode()
              ^ (obj?.Creator?? String.Empty).GetHashCode()
              ^ (obj?.Created?? DateTime.MinValue).GetHashCode());
    }
  }
}
