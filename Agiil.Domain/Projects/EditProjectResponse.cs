using System;
using CSF.Entities;
using CSF.Validation;

namespace Agiil.Domain.Projects
{
    public class EditProjectResponse
    {
        readonly IValidationResultInterpreter resultInterpreter;

        public bool NameMustNotBeEmpty
            => resultInterpreter.IncludesFailureFor<EditProjectRequest>(ValidationResult, x => x.Name);

        public bool CodeMustHaveCorrectLength
            => resultInterpreter.IncludesFailureFor<EditProjectRequest>(ValidationResult, x => x.Code);

        public bool CodeMustBeUnique
            => resultInterpreter.IncludesFailureFor<EditProjectRequest>(ValidationResult, name: "UniqueCode");

        public IValidationResult ValidationResult { get; set; }

        public Project Project { get; set; }

        public bool IsSuccess => ValidationResult?.IsSuccess == true;

        public EditProjectResponse(IValidationResultInterpreter resultInterpreter)
        {
            this.resultInterpreter = resultInterpreter ?? throw new ArgumentNullException(nameof(resultInterpreter));
        }
    }
}
