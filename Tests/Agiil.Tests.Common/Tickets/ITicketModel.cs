using System;
using Agiil.Domain.Tickets;
using CSF.Entities;

namespace Agiil.Tests.Tickets
{
  public interface ITicketModel
  {
    void Remove(IIdentity<Ticket> id);
  }
}
