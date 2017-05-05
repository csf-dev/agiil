using System;
using System.Linq.Expressions;
using Agiil.Domain.Tickets;

namespace Agiil.Tests.Tickets
{
  public interface ITicketQueryController
  {
    bool DoesTicketExist(TicketSearchCriteria searchHelper = null);
  }
}
