﻿using System;
using System.Linq.Expressions;
using CSF.Specifications;

namespace Agiil.Domain.Tickets.Specs
{
  public class IsOpen : ISpecificationExpression<Ticket>
  {
    public Expression<Func<Ticket, bool>> GetExpression()
    {
      return ticket => !ticket.Closed;
    }
  }
}
