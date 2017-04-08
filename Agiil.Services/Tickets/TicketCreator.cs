using System;
using Agiil.Domain.Tickets;
using Agiil.Services.Auth;
using NHibernate;

namespace Agiil.Services.Tickets
{
  public class TicketCreator : ITicketCreator
  {
    readonly ISession session;
    readonly ICurrentUserReader userReader;
    readonly ITicketFactory ticketFactory;

    public Ticket Create(CreateTicketRequest request)
    {
      if(request == null)
      {
        throw new ArgumentNullException(nameof(request));
      }

      var user = userReader.RequireCurrentUser();
      var ticket = ticketFactory.CreateTicket(request.Title, request.Description, user);

      session.Save(ticket);

      return ticket;
    }

    public TicketCreator(ISession session,
                         ICurrentUserReader userReader,
                         ITicketFactory ticketFactory)
    {
      if(ticketFactory == null)
        throw new ArgumentNullException(nameof(ticketFactory));
      if(userReader == null)
        throw new ArgumentNullException(nameof(userReader));
      if(session == null)
        throw new ArgumentNullException(nameof(session));

      this.ticketFactory = ticketFactory;
      this.userReader = userReader;
      this.session = session;
    }
  }
}
