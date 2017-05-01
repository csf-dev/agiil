using System;
using Agiil.Domain.Auth;
using Agiil.Domain.Data;
using CSF.Validation;
using NHibernate;

namespace Agiil.Domain.Tickets
{
  public class TicketCreator : ITicketCreator
  {
    readonly IPersister persister;
    readonly ICurrentUserReader userReader;
    readonly ITicketFactory ticketFactory;
    readonly ITransactionFactory transactionFactory;
    readonly ICreateTicketValidatorFactory validatorFactory;

    public CreateTicketResponse Create(CreateTicketRequest request)
    {
      if(request == null)
      {
        throw new ArgumentNullException(nameof(request));
      }

      var validationResult = ValidateRequest(request);
      if(!validationResult.IsSuccess)
        return new CreateTicketResponse(validationResult);

      Ticket ticket;

      using(var trans = transactionFactory.BeginTransaction())
      {
        ticket = CreateTicket(request);
        persister.Save(ticket);
        trans.RequestCommit();
      }

      return new CreateTicketResponse(validationResult, ticket);
    }

    IValidationResult ValidateRequest(CreateTicketRequest request)
    {
      var validator = validatorFactory.GetValidator();
      return validator.Validate(request);
    }

    Ticket CreateTicket(CreateTicketRequest request)
    {
      return ticketFactory.CreateTicket(request.Title, request.Description, userReader.RequireCurrentUser());
    }

    public TicketCreator(IPersister persister,
                         ICurrentUserReader userReader,
                         ITicketFactory ticketFactory,
                         ITransactionFactory transactionFactory,
                         ICreateTicketValidatorFactory validatorFactory)
    {
      if(validatorFactory == null)
        throw new ArgumentNullException(nameof(validatorFactory));
      if(transactionFactory == null)
        throw new ArgumentNullException(nameof(transactionFactory));
      if(ticketFactory == null)
        throw new ArgumentNullException(nameof(ticketFactory));
      if(userReader == null)
        throw new ArgumentNullException(nameof(userReader));
      if(persister == null)
        throw new ArgumentNullException(nameof(persister));

      this.ticketFactory = ticketFactory;
      this.userReader = userReader;
      this.persister = persister;
      this.transactionFactory = transactionFactory;
      this.validatorFactory = validatorFactory;
    }
  }
}
