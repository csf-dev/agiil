﻿using System;
using Agiil.Domain.Tickets;
using CSF.Data.Specifications;

namespace Agiil.Domain.TicketSearch
{
  public interface IGetsTicketSpecification : ISearchNode
  {
    ISpecificationExpression<Ticket> GetSpecification();
  }
}
