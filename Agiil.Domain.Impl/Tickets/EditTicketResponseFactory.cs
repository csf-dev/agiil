using System;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public class EditTicketResponseFactory : ICreatesEditTicketResponse
  {
    readonly IValidationResultInterpreter resultInterpreter;

    public EditTicketResponse GetResponse(IValidationResult validationResult)
    {
      return new EditTicketResponse(validationResult, resultInterpreter);
    }

    public EditTicketResponse GetResponse(IValidationResult validationResult, Ticket ticket)
    {
      return new EditTicketResponse(validationResult, resultInterpreter, ticket);
    }

    public EditTicketResponseFactory(IValidationResultInterpreter resultInterpreter)
    {
      if(resultInterpreter == null)
        throw new ArgumentNullException(nameof(resultInterpreter));
      this.resultInterpreter = resultInterpreter;
    }
  }
}
