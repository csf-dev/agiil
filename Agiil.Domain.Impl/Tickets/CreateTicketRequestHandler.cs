using System;
using Agiil.Domain.Validation;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public class CreateTicketRequestHandler : IHandlesCreateTicketRequest
  {
    readonly ICreatesTicket ticketFactory;
    readonly ICreatesValidators<CreateTicketRequest> validatorFactory;
    readonly ICreatesCreateTicketResponse responseCreator;

    public CreateTicketResponse Create(CreateTicketRequest request)
    {
      var validationResult = ValidateRequest(request);
      if(!validationResult.IsSuccess)
        return responseCreator.GetResponse(validationResult);

      var ticket = ticketFactory.CreateTicket(request);

      return responseCreator.GetResponse(validationResult, ticket);
    }

    IValidationResult ValidateRequest(CreateTicketRequest request)
    {
      var validator = validatorFactory.GetValidator();
      return validator.Validate(request);
    }

    public CreateTicketRequestHandler(ICreatesTicket ticketFactory,
                                      ICreatesValidators<CreateTicketRequest> validatorFactory,
                                      ICreatesCreateTicketResponse responseCreator)
    {
      if(responseCreator == null)
        throw new ArgumentNullException(nameof(responseCreator));
      if(validatorFactory == null)
        throw new ArgumentNullException(nameof(validatorFactory));
      if(ticketFactory == null)
        throw new ArgumentNullException(nameof(ticketFactory));

      this.ticketFactory = ticketFactory;
      this.validatorFactory = validatorFactory;
      this.responseCreator = responseCreator;
    }
  }
}
