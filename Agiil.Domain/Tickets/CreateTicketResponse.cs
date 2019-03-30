using System;
using System.Linq;
using CSF.Reflection;
using CSF.Validation;
using CSF.Validation.Manifest;

namespace Agiil.Domain.Tickets
{
  public class CreateTicketResponse
  {
    readonly IValidationResult validationResult;
    readonly IValidationResultInterpreter resultInterpreter;

    public Ticket Ticket { get; private set; }

    public bool TitleIsInvalid
      => resultInterpreter.IncludesFailureFor<CreateTicketRequest>(validationResult, x => x.Title);

    public bool DescriptionIsInvalid
      => resultInterpreter.IncludesFailureFor<CreateTicketRequest>(validationResult, x => x.Description);

    public bool SprintIsInvalid
      => resultInterpreter.IncludesFailureFor<CreateTicketRequest>(validationResult, x => x.SprintIdentity);

    public bool IsSuccess
      => validationResult.IsSuccess && Ticket != null;

    public bool StoryPointsAreInvalid
      => resultInterpreter.IncludesFailureFor<CreateTicketRequest>(validationResult, x => x.StoryPoints);

    protected CreateTicketResponse() {}

    public CreateTicketResponse(IValidationResult result,
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
