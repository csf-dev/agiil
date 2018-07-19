using System;
namespace Agiil.Domain.TicketSearch
{
  public abstract class Value
  {
    public void Accept(IVisitsTicketSearch visitor) { visitor?.Visit(this); }
  }
}
