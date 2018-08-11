using System;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public interface ICreatesEditTicketResponse
  {
    EditTicketResponse GetResponse(IValidationResult validationResult);

    EditTicketResponse GetResponse(IValidationResult validationResult, Ticket ticket);
  }
}
