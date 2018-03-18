using System;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public class CreateTicketResponseFactory : ICreatesCreateTicketResponse
  {
    readonly IValidationResultInterpreter resultInterpreter;

    public CreateTicketResponse GetResponse(IValidationResult validationResult)
    {
      return new CreateTicketResponse(validationResult, resultInterpreter);
    }

    public CreateTicketResponse GetResponse(IValidationResult validationResult, Ticket ticket)
    {
      return new CreateTicketResponse(validationResult, resultInterpreter, ticket);
    }

    public CreateTicketResponseFactory(IValidationResultInterpreter resultInterpreter)
    {
      if(resultInterpreter == null)
        throw new ArgumentNullException(nameof(resultInterpreter));
      this.resultInterpreter = resultInterpreter;
    }
  }
}
