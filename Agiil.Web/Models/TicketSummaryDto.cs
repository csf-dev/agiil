using System;
namespace Agiil.Web.Models
{
  public class TicketSummaryDto : IEquatable<TicketSummaryDto>
  {
    public string Title { get; set; }

    public string Creator { get; set; }

    public DateTime Created { get; set; }

    public string CreationTimestamp => Created.ToString("u");

    public string ShortTimestamp => Created.ToString("D");

    public override bool Equals(object obj)
    {
      return Equals(obj as TicketSummaryDto);
    }

    public virtual bool Equals(TicketSummaryDto other)
    {
      if(ReferenceEquals(this, other))
        return true;
      if(ReferenceEquals(other, null))
        return false;

      return (Title == other.Title
              && Creator == other.Creator
              && Created == other.Created);
    }

    public override int GetHashCode()
    {
      return ((Title?? String.Empty).GetHashCode()
              ^ (Creator?? String.Empty).GetHashCode()
              ^ Created.GetHashCode());
    }
  }
}
