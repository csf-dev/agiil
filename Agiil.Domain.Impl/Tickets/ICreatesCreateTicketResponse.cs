using System;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public interface ICreatesCreateTicketResponse
  {
    CreateTicketResponse GetResponse(IValidationResult validationResult);

    CreateTicketResponse GetResponse(IValidationResult validationResult, Ticket ticket);
  }
}
