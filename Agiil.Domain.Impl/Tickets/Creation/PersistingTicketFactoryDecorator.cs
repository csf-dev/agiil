using System;
using CSF.Data;
using CSF.Data.Entities;

namespace Agiil.Domain.Tickets.Creation
{
  public class PersistingTicketFactoryDecorator : ICreatesTicket
  {
    readonly ICreatesTicket wrappedInstance;
    readonly ITransactionCreator transactionFactory;
    readonly IEntityData data;

    public Ticket CreateTicket(CreateTicketRequest request)
    {
      using(var trans = transactionFactory.BeginTransaction())
      {
        var ticket = wrappedInstance.CreateTicket(request);
        data.Add(ticket);
        trans.Commit();
        return ticket;
      }
    }

    public PersistingTicketFactoryDecorator(ICreatesTicket wrappedInstance,
                                            ITransactionCreator transactionFactory,
                                            IEntityData data)
    {
      if(transactionFactory == null)
        throw new ArgumentNullException(nameof(transactionFactory));
      if(wrappedInstance == null)
        throw new ArgumentNullException(nameof(wrappedInstance));
      if(data == null)
        throw new ArgumentNullException(nameof(data));

      this.wrappedInstance = wrappedInstance;
      this.transactionFactory = transactionFactory;
      this.data = data;
    }
  }
}
