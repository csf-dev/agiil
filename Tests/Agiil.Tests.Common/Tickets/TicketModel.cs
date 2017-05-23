using System;
using Agiil.Domain.Tickets;
using CSF.Data.Entities;
using CSF.Entities;

namespace Agiil.Tests.Tickets
{
  public class TicketModel : ITicketModel
  {
    readonly IRepository<Ticket> repo;

    public void Remove(IIdentity<Ticket> id)
    {
      if(ReferenceEquals(id, null))
        return;

      var ticket = repo.Get(id);
      if(ReferenceEquals(ticket, null))
        return;
      
      repo.Remove(ticket);
    }

    public TicketModel(IRepository<Ticket> repo)
    {
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      this.repo = repo;
    }
  }
}
