using System;
using Agiil.Domain.Auth;
using CSF.Data;
using CSF.Data.Entities;
using CSF.Validation;
using NHibernate;

namespace Agiil.Domain.Tickets
{
  public class TicketCreator : ITicketCreator
  {
    readonly IRepository<Ticket> ticketRepo;
    readonly ICurrentUserReader userReader;
    readonly ITicketFactory ticketFactory;
    readonly ITransactionCreator transactionFactory;
    readonly ICreateTicketValidatorFactory validatorFactory;
    Func<IValidationResult, Ticket, CreateTicketResponse> responseCreator;

    public CreateTicketResponse Create(CreateTicketRequest request)
    {
      var validationResult = ValidateRequest(request);
      if(!validationResult.IsSuccess)
        return responseCreator(validationResult, null);

      Ticket ticket;

      using(var trans = transactionFactory.BeginTransaction())
      {
        ticket = CreateTicket(request);
        ticketRepo.Add(ticket);
        trans.Commit();
      }

      return responseCreator(validationResult, ticket);
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

    internal Func<IValidationResult, Ticket, CreateTicketResponse> ResponseCreator
    {
      get { return responseCreator; }
      set { responseCreator = value; }
    }

    public TicketCreator(IRepository<Ticket> ticketRepo,
                         ICurrentUserReader userReader,
                         ITicketFactory ticketFactory,
                         ITransactionCreator transactionFactory,
                         ICreateTicketValidatorFactory validatorFactory,
                         Func<IValidationResult,Ticket,CreateTicketResponse> responseCreator)
    {
      if(responseCreator == null)
        throw new ArgumentNullException(nameof(responseCreator));
      if(validatorFactory == null)
        throw new ArgumentNullException(nameof(validatorFactory));
      if(transactionFactory == null)
        throw new ArgumentNullException(nameof(transactionFactory));
      if(ticketFactory == null)
        throw new ArgumentNullException(nameof(ticketFactory));
      if(userReader == null)
        throw new ArgumentNullException(nameof(userReader));
      if(ticketRepo == null)
        throw new ArgumentNullException(nameof(ticketRepo));

      this.ticketFactory = ticketFactory;
      this.userReader = userReader;
      this.ticketRepo = ticketRepo;
      this.transactionFactory = transactionFactory;
      this.validatorFactory = validatorFactory;
      this.responseCreator = responseCreator;
    }
  }
}
