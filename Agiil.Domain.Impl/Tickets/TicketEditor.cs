using System;
using Agiil.Domain.Validation;
using CSF.Data;
using CSF.Data.Entities;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public class TicketEditor : ITicketEditor
  {
    readonly IRepository<Ticket> ticketRepo;
    readonly ITransactionCreator transactionFactory;
    readonly IValidatorFactory<EditTicketTitleAndDescriptionRequest> validatorFactory;
    readonly Func<IValidationResult, Ticket, EditTicketTitleAndDescriptionResponse> responseCreator;

    public EditTicketTitleAndDescriptionResponse Edit(EditTicketTitleAndDescriptionRequest request)
    {
      var validationResult = ValidateRequest(request);
      if(!validationResult.IsSuccess)
        return responseCreator(validationResult, null);

      Ticket ticket;

      using(var trans = transactionFactory.BeginTransaction())
      {
        ticket = ticketRepo.Get(request.Identity);
        MapChangesToTicket(request, ticket);
        ticketRepo.Update(ticket);
        trans.Commit();
      }

      return responseCreator(validationResult, ticket);
    }

    IValidationResult ValidateRequest(EditTicketTitleAndDescriptionRequest request)
    {
      var validator = validatorFactory.GetValidator();
      return validator.Validate(request);
    }

    void MapChangesToTicket(EditTicketTitleAndDescriptionRequest request, Ticket ticket)
    {
      ticket.Title = request.Title;
      ticket.Description = request.Description;
    }

    public TicketEditor(IRepository<Ticket> ticketRepo,
                        ITransactionCreator transactionFactory,
                        IValidatorFactory<EditTicketTitleAndDescriptionRequest> validatorFactory,
                        Func<IValidationResult, Ticket, EditTicketTitleAndDescriptionResponse> responseCreator)
    {
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
    }
  }
}
