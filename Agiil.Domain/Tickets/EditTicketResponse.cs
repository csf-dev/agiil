using System;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public class EditTicketResponse
  {
    readonly IValidationResult validationResult;
    readonly IValidationResultInterpreter resultInterpreter;

    public Ticket Ticket { get; private set; }

    public bool IdentityIsInvalid
    {
      get {
        return resultInterpreter.IncludesFailureFor<EditTicketRequest>(validationResult,
                                                                                          x => x.Identity);
      }
    }

    public bool TitleIsInvalid
    {
      get {
        return resultInterpreter.IncludesFailureFor<EditTicketRequest>(validationResult,
                                                                                          x => x.Title);
      }
    }

    public bool DescriptionIsInvalid
    {
      get {
        return resultInterpreter.IncludesFailureFor<EditTicketRequest>(validationResult,
                                                                                          x => x.Description);
      }
    }

    public bool SprintIsInvalid
     => resultInterpreter.IncludesFailureFor<EditTicketRequest>(validationResult, x => x.SprintIdentity);

    public bool IsSuccess => validationResult.IsSuccess;

    public EditTicketResponse(IValidationResult result,
                                                 IValidationResultInterpreter resultInterpreter,
                                                 Ticket createdTicket = null)
    {
      if(resultInterpreter == null)
        throw new ArgumentNullException(nameof(resultInterpreter));
      if(result == null)
        throw new ArgumentNullException(nameof(result));

      Ticket = createdTicket;
      this.validationResult = result;
      this.resultInterpreter = resultInterpreter;
    }
  }
}
