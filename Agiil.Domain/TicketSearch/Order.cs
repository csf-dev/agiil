using System;
namespace Agiil.Domain.TicketSearch
{
  public class Order
  {
    public bool Descending { get; set; }

    public Value Element { get; set; }

    public void Accept(IVisitsTicketSearch visitor) { visitor?.Visit(this); }
  }
}
