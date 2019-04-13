using System;
using CSF.Data;
using CSF.Data.Entities;
using log4net;

namespace Agiil.Domain.Tickets.Creation
{
  public class PersistingTicketFactoryDecorator : ICreatesTicket
  {
    readonly ICreatesTicket wrappedInstance;
    readonly ITransactionCreator transactionFactory;
    readonly IEntityData data;
    readonly ILog logger;

    public Ticket CreateTicket(CreateTicketRequest request)
    {
      using(var trans = transactionFactory.BeginTransaction())
      {
        var ticket = wrappedInstance.CreateTicket(request);
        data.Add(ticket);
        trans.Commit();
        logger.InfoFormat("Created ticket {0}: {1}", ticket.GetTicketReference().ToString(true), ticket.Title);
        return ticket;
      }
    }

    public PersistingTicketFactoryDecorator(ICreatesTicket wrappedInstance,
                                            ITransactionCreator transactionFactory,
                                            IEntityData data,
                                            ILog logger)
    {
      if(logger == null)
        throw new ArgumentNullException(nameof(logger));
      if(transactionFactory == null)
        throw new ArgumentNullException(nameof(transactionFactory));
      if(wrappedInstance == null)
        throw new ArgumentNullException(nameof(wrappedInstance));
      if(data == null)
        throw new ArgumentNullException(nameof(data));

      this.wrappedInstance = wrappedInstance;
      this.transactionFactory = transactionFactory;
      this.data = data;
      this.logger = logger;
    }
  }
}
