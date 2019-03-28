using System;
using Agiil.Domain.Auth;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Domain.Activity
{
  public class TicketWorkLog : Entity<long>
  {
    public virtual User User { get; set; }

    public virtual Ticket Ticket { get; set; }

    public virtual DateTime TimeStarted { get; set; }

    int minutesSpent;
    public virtual int MinutesSpent
    {
      get { return minutesSpent; }
      set { minutesSpent = (value < 0)? 0 : value; }
    }

    public virtual TimeSpan TimeSpent
    {
      get { return TimeSpan.FromMinutes(MinutesSpent); }
      set { MinutesSpent = (int) value.TotalMinutes; }
    }
  }
}
