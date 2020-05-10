using System;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
    public class EditTicketResponse
    {
        readonly IValidationResultInterpreter resultInterpreter;

        public readonly IValidationResult ValidationResult;

        public Ticket Ticket { get; private set; }

        public bool IdentityIsInvalid
            => resultInterpreter.IncludesFailureFor<EditTicketRequest>(ValidationResult, x => x.Identity);

        public bool TitleIsInvalid
            => resultInterpreter.IncludesFailureFor<EditTicketRequest>(ValidationResult, x => x.Title);

        public bool DescriptionIsInvalid
            => resultInterpreter.IncludesFailureFor<EditTicketRequest>(ValidationResult, x => x.Description);

        public bool SprintIsInvalid
            => resultInterpreter.IncludesFailureFor<EditTicketRequest>(ValidationResult, x => x.SprintIdentity);

        public bool StoryPointsAreInvalid
            => resultInterpreter.IncludesFailureFor<EditTicketRequest>(ValidationResult, x => x.StoryPoints);

        public bool IsSuccess => ValidationResult.IsSuccess;

        protected EditTicketResponse() { }

        public EditTicketResponse(IValidationResult result,
                                  IValidationResultInterpreter resultInterpreter,
                                  Ticket createdTicket = null)
        {
            Ticket = createdTicket;
            this.ValidationResult = result ?? throw new ArgumentNullException(nameof(result));
            this.resultInterpreter = resultInterpreter ?? throw new ArgumentNullException(nameof(resultInterpreter));
        }
    }
}
