using System;
using CSF.Data;
using CSF.Data.Entities;

namespace Agiil.Domain.Tickets
{
  public class TicketOpenerCloser : ITicketOpenerCloser
  {
    readonly IEntityData repo;
    readonly ITransactionCreator transactionFactory;

    public CloseTicketResponse Close(CloseTicketRequest request)
    {
      if(request == null)
        throw new ArgumentNullException(nameof(request));

      using(var trans = transactionFactory.BeginTransaction())
      {
        var ticket = repo.Get(request.Identity);
        if(ReferenceEquals(ticket, null))
          return new CloseTicketResponse { TicketNotFound = true };

        if(ticket.Closed)
          return new CloseTicketResponse { TicketAlreadyClosed = true };

        ticket.Closed = true;
        repo.Update(ticket);
        trans.Commit();
      }

      return new CloseTicketResponse();
    }

    public ReopenTicketResponse Reopen(ReopenTicketRequest request)
    {
      if(request == null)
        throw new ArgumentNullException(nameof(request));

      using(var trans = transactionFactory.BeginTransaction())
      {
        var ticket = repo.Get(request.Identity);
        if(ReferenceEquals(ticket, null))
          return new ReopenTicketResponse { TicketNotFound = true };

        if(!ticket.Closed)
          return new ReopenTicketResponse { TicketAlreadyOpen = true };

        ticket.Closed = false;
        repo.Update(ticket);
        trans.Commit();
      }

      return new ReopenTicketResponse();
    }

    public TicketOpenerCloser(IEntityData repo,
                              ITransactionCreator transactionFactory)
    {
      if(transactionFactory == null)
        throw new ArgumentNullException(nameof(transactionFactory));
      if(repo == null)
        throw new ArgumentNullException(nameof(repo));
      this.transactionFactory = transactionFactory;
      this.repo = repo;
    }
  }
}
