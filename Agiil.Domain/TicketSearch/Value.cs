using System;
namespace Agiil.Domain.TicketSearch
{
  public abstract class Value
  {
    public virtual void Accept(IVisitsTicketSearch visitor) { visitor?.Visit(this); }
  }
}
