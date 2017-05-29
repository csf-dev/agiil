using System;
using Agiil.Domain.Auth;
using Agiil.Domain.Sprints;
using Agiil.Domain.Validation;
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
    readonly IValidatorFactory<CreateTicketRequest> validatorFactory;
    Func<IValidationResult, Ticket, CreateTicketResponse> responseCreator;
    readonly IRepository<Sprint> sprintRepo;

    // TODO: This class has too many dependencies and thus too many responsibilities
    // Refactor and push some of these outwards

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
      var ticket = ticketFactory.CreateTicket(request.Title,
                                              request.Description,
                                              userReader.RequireCurrentUser());
      
      if(request.SprintIdentity != null)
        ticket.Sprint = sprintRepo.Theorise(request.SprintIdentity);
      
      return ticket;
    }

    // TODO: #AG8 - Refactor this into a factory type
    public Func<IValidationResult, Ticket, CreateTicketResponse> ResponseCreator
    {
      get { return responseCreator; }
      set { responseCreator = value; }
    }

    public TicketCreator(IRepository<Ticket> ticketRepo,
                         ICurrentUserReader userReader,
                         ITicketFactory ticketFactory,
                         ITransactionCreator transactionFactory,
                         IValidatorFactory<CreateTicketRequest> validatorFactory,
                         Func<IValidationResult,Ticket,CreateTicketResponse> responseCreator,
                         IRepository<Sprint> sprintRepo)
    {
      if(sprintRepo == null)
        throw new ArgumentNullException(nameof(sprintRepo));
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
      this.sprintRepo = sprintRepo;
    }
  }
}
