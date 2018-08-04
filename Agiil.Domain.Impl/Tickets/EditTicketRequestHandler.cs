using System;
using Agiil.Domain.Validation;
using AutoMapper;
using CSF.Data;
using CSF.Data.Entities;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public class EditTicketRequestHandler : IHandlesEditTicketRequest
  {
    readonly IEntityData ticketRepo;
    readonly ITransactionCreator transactionFactory;
    readonly ICreatesValidators<EditTicketRequest> validatorFactory;
    readonly ICreatesEditTicketResponse responseCreator;
    readonly IMapper mapper;

    public EditTicketResponse Edit(EditTicketRequest request)
    {
      var validationResult = ValidateRequest(request);
      if(!validationResult.IsSuccess)
        return responseCreator.GetResponse(validationResult, null);

      Ticket ticket;

      using(var trans = transactionFactory.BeginTransaction())
      {
        ticket = ticketRepo.Get(request.Identity);
        mapper.Map(request, ticket);
        ticketRepo.Update(ticket);
        trans.Commit();
      }

      return responseCreator.GetResponse(validationResult, ticket);
    }

    IValidationResult ValidateRequest(EditTicketRequest request)
    {
      var validator = validatorFactory.GetValidator();
      return validator.Validate(request);
    }

    public EditTicketRequestHandler(IEntityData ticketRepo,
                                    ITransactionCreator transactionFactory,
                                    ICreatesValidators<EditTicketRequest> validatorFactory,
                                    ICreatesEditTicketResponse responseCreator,
                                    IMapper mapper)
    {
      if(mapper == null)
        throw new ArgumentNullException(nameof(mapper));
      if(responseCreator == null)
        throw new ArgumentNullException(nameof(responseCreator));
      if(validatorFactory == null)
        throw new ArgumentNullException(nameof(validatorFactory));
      if(transactionFactory == null)
        throw new ArgumentNullException(nameof(transactionFactory));
      if(ticketRepo == null)
        throw new ArgumentNullException(nameof(ticketRepo));
      
      this.ticketRepo = ticketRepo;
      this.transactionFactory = transactionFactory;
      this.validatorFactory = validatorFactory;
      this.responseCreator = responseCreator;
      this.mapper = mapper;
    }
  }
}
