﻿using System;
namespace Agiil.Domain.TicketSearch
{
  public class ConstantValue : Value
  {
    public string Text { get; set; }

    public void Accept(IVisitsTicketSearch visitor) { visitor?.Visit(this); }
	}
}
