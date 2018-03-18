using System;
using Agiil.Domain.Validation;
using AutoMapper;
using CSF.Data;
using CSF.Data.Entities;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public class TicketEditor : ITicketEditor
  {
    readonly IEntityData ticketRepo;
    readonly ITransactionCreator transactionFactory;
    readonly ICreatesValidators<EditTicketRequest> validatorFactory;
    readonly Func<IValidationResult, Ticket, EditTicketResponse> responseCreator;
    readonly IMapper mapper;

    public EditTicketResponse Edit(EditTicketRequest request)
    {
      var validationResult = ValidateRequest(request);
      if(!validationResult.IsSuccess)
        return responseCreator(validationResult, null);

      Ticket ticket;

      using(var trans = transactionFactory.BeginTransaction())
      {
        ticket = ticketRepo.Get(request.Identity);
        mapper.Map(request, ticket);
        ticketRepo.Update(ticket);
        trans.Commit();
      }

      return responseCreator(validationResult, ticket);
    }

    IValidationResult ValidateRequest(EditTicketRequest request)
    {
      var validator = validatorFactory.GetValidator();
      return validator.Validate(request);
    }

    public TicketEditor(IEntityData ticketRepo,
                        ITransactionCreator transactionFactory,
                        ICreatesValidators<EditTicketRequest> validatorFactory,
                        Func<IValidationResult, Ticket, EditTicketResponse> responseCreator,
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
