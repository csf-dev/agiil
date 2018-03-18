﻿using System;
using Agiil.Domain.Auth;
using Agiil.Domain.Validation;
using CSF.Data;
using CSF.Data.Entities;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public class TicketCreator : ITicketCreator
  {
    readonly IEntityData data;
    readonly ICurrentUserReader userReader;
    readonly ITicketFactory ticketFactory;
    readonly ITransactionCreator transactionFactory;
    readonly ICreatesValidators<CreateTicketRequest> validatorFactory;
    readonly ICreatesCreateTicketResponse responseCreator;

    // TODO: This class has too many dependencies and thus too many responsibilities
    // Refactor and push some of these outwards

    public CreateTicketResponse Create(CreateTicketRequest request)
    {
      var validationResult = ValidateRequest(request);
      if(!validationResult.IsSuccess)
        return responseCreator.GetResponse(validationResult);

      Ticket ticket;

      using(var trans = transactionFactory.BeginTransaction())
      {
        ticket = CreateTicket(request);
        data.Add(ticket);
        trans.Commit();
      }

      return responseCreator.GetResponse(validationResult, ticket);
    }

    IValidationResult ValidateRequest(CreateTicketRequest request)
    {
      var validator = validatorFactory.GetValidator();
      return validator.Validate(request);
    }

    Ticket CreateTicket(CreateTicketRequest request)
    {
      var type = data.Theorise(request.TicketTypeIdentity);
      var ticket = ticketFactory.CreateTicket(request.Title,
                                              request.Description,
                                              userReader.RequireCurrentUser(),
                                              type);
      
      if(request.SprintIdentity != null)
        ticket.Sprint = data.Theorise(request.SprintIdentity);
      
      return ticket;
    }

    public TicketCreator(IEntityData data,
                         ICurrentUserReader userReader,
                         ITicketFactory ticketFactory,
                         ITransactionCreator transactionFactory,
                         ICreatesValidators<CreateTicketRequest> validatorFactory,
                         ICreatesCreateTicketResponse responseCreator)
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
      if(data == null)
        throw new ArgumentNullException(nameof(data));

      this.ticketFactory = ticketFactory;
      this.userReader = userReader;
      this.data = data;
      this.transactionFactory = transactionFactory;
      this.validatorFactory = validatorFactory;
      this.responseCreator = responseCreator;
    }
  }
}
