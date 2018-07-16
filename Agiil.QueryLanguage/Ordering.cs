using System;
using System.Collections.Generic;

namespace Agiil.QueryLanguage
{
  public class Ordering
  {
    IList<Order> orders;

    public IList<Order> Orders
    {
      get { return orders; }
      set { orders = value ?? new List<Order>(); }
    }

    public Ordering()
    {
      orders = new List<Order>();
    }
  }
}
