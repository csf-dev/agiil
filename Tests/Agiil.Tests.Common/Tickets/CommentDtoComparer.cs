using System;
using System.Collections;
using System.Collections.Generic;
using Agiil.Web.Models;

namespace Agiil.Tests.Tickets
{
  public class CommentDtoComparer : IEqualityComparer<CommentDto>, IComparer
  {
    public int Compare(object x, object y)
    {
      if(ReferenceEquals(x, y))
        return 0;

      CommentDto
        first = x as CommentDto,
        second = y as CommentDto;

      if(ReferenceEquals(first, null))
        return -1;
      if(ReferenceEquals(second, null))
        return 1;

      if(Equals(first, second))
        return 0;

      return (first.CreationTimestamp > second.CreationTimestamp)? 1 : -1;
    }

    public virtual bool Equals(CommentDto x, CommentDto y)
    {
      if(ReferenceEquals(x, y))
        return true;
      if(ReferenceEquals(x, null))
        return false;
      if(ReferenceEquals(y, null))
        return false;

      return (x.Author == y.Author
              && x.CreationTimestamp == y.CreationTimestamp
              && x.Body == y.Body);
    }

    public virtual int GetHashCode(CommentDto obj)
    {
      if(ReferenceEquals(obj, null))
        return 0;

      return ((obj?.Author?? String.Empty).GetHashCode()
              ^ (obj?.Body?? String.Empty).GetHashCode()
              ^ (obj?.CreationTimestamp).GetHashCode());
    }
  }
}
