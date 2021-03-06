﻿using System;
using System.Collections.Generic;

namespace Agiil.Domain.TicketSearch
{
  public class Ordering
  {
    IList<Order> orders;

    public IList<Order> Orders
    {
      get { return orders; }
      set { orders = value ?? new List<Order>(); }
    }

    public void Accept(IVisitsTicketSearch visitor) { visitor?.Visit(this); }

    public Ordering()
    {
      orders = new List<Order>();
    }
  }
}
