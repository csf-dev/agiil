using System;
using System.Collections.Generic;
using System.Linq;
using Agiil.Domain.Auth;
using Agiil.Domain.Tickets;
using CSF.Data;
using CSF.Data.Entities;

namespace Agiil.Tests.Tickets
{
  public class BulkTicketCreator : IBulkTicketCreator
  {
    readonly IRepository<Ticket> ticketRepo;
    readonly IRepository<User> userRepo;
    readonly ITicketFactory ticketFactory;
    readonly ITransactionCreator transactionFactory;

    public void CreateTickets(IEnumerable<BulkTicketSpecification> ticketSpecs)
    {
      if(ticketSpecs == null)
      {
        throw new ArgumentNullException(nameof(ticketSpecs));
      }

      using(var trans = transactionFactory.BeginTransaction())
      {
        foreach(var spec in ticketSpecs)
        {
          if(ReferenceEquals(spec, null))
            continue;
          
          var ticket = CreateTicket(spec);
          ticketRepo.Add(ticket);
        }

        trans.Commit();
      }
    }

    Ticket CreateTicket(BulkTicketSpecification spec)
    {
      var user = GetUser(spec);
      var ticket = ticketFactory.CreateTicket(spec.Title, spec.Description, user);
      ConfigureTicket(spec, ticket);
      return ticket;
    }

    void ConfigureTicket(BulkTicketSpecification spec, Ticket ticket)
    {
      if(ReferenceEquals(ticket, null))
        return;
      
      ticket.CreationTimestamp = spec.Created;

      if(spec.Id.HasValue)
        ticket.SetIdentityValue(spec.Id.Value);

      if(spec.Closed)
        ticket.Closed = true;
    }

    User GetUser(BulkTicketSpecification spec)
    {
      var user = userRepo
        .Query()
        .FirstOrDefault(x => x.Username.Equals(spec.Creator, StringComparison.InvariantCultureIgnoreCase));
      
      if(ReferenceEquals(user, null))
        user = userRepo.Query().First();

      return user;
    }

    public BulkTicketCreator(IRepository<Ticket> ticketRepo,
                             IRepository<User> userRepo,
                             ITicketFactory ticketFactory,
                             ITransactionCreator transactionFactory)
    {
      if(transactionFactory == null)
        throw new ArgumentNullException(nameof(transactionFactory));
      if(ticketFactory == null)
        throw new ArgumentNullException(nameof(ticketFactory));
      if(userRepo == null)
        throw new ArgumentNullException(nameof(userRepo));
      if(ticketRepo == null)
        throw new ArgumentNullException(nameof(ticketRepo));

      this.ticketRepo = ticketRepo;
      this.userRepo = userRepo;
      this.ticketFactory = ticketFactory;
      this.transactionFactory = transactionFactory;
    }
  }
}
