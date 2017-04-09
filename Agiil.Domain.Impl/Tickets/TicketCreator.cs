using System;
using Agiil.Domain.Auth;
using Agiil.Domain.Data;
using NHibernate;

namespace Agiil.Domain.Tickets
{
  public class TicketCreator : ITicketCreator
  {
    readonly ISession session;
    readonly ICurrentUserReader userReader;
    readonly ITicketFactory ticketFactory;
    readonly ITransactionFactory transactionFactory;

    public Ticket Create(CreateTicketRequest request)
    {
      if(request == null)
      {
        throw new ArgumentNullException(nameof(request));
      }

      Ticket ticket;

      using(var trans = transactionFactory.BeginTransaction())
      {
        var user = userReader.RequireCurrentUser();
        ticket = ticketFactory.CreateTicket(request.Title,
                                            request.Description,
                                            user);
        session.Save(ticket);
        trans.RequestCommit();
      }

      return ticket;
    }

    public TicketCreator(ISession session,
                         ICurrentUserReader userReader,
                         ITicketFactory ticketFactory,
                         ITransactionFactory transactionFactory)
    {
      if(transactionFactory == null)
        throw new ArgumentNullException(nameof(transactionFactory));
      if(ticketFactory == null)
        throw new ArgumentNullException(nameof(ticketFactory));
      if(userReader == null)
        throw new ArgumentNullException(nameof(userReader));
      if(session == null)
        throw new ArgumentNullException(nameof(session));

      this.ticketFactory = ticketFactory;
      this.userReader = userReader;
      this.session = session;
      this.transactionFactory = transactionFactory;
    }
  }
}
