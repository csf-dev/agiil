using System;
using CSF.Entities;
using CSF.Validation;

namespace Agiil.Domain.Projects
{
    public class CreateProjectResponse
    {
        readonly IValidationResultInterpreter resultInterpreter;

        public bool NameMustNotBeEmpty
            => resultInterpreter.IncludesFailureFor<CreateProjectRequest>(ValidationResult, x => x.Name);

        public bool CodeMustBeUniqueAndHaveCorrectLength
            => resultInterpreter.IncludesFailureFor<CreateProjectRequest>(ValidationResult, x => x.Code);

        public IIdentity<Project> ProjectIdentity { get; set; }

        public IValidationResult ValidationResult { get; set; }

        public bool IsSuccess => (ValidationResult?.IsSuccess == true) && ProjectIdentity != null;

        public int MinCodeLength => Project.MinCodeLength;

        public int MaxCodeLength => Project.MaxCodeLength;

        public CreateProjectResponse(IValidationResultInterpreter resultInterpreter)
        {
            this.resultInterpreter = resultInterpreter ?? throw new ArgumentNullException(nameof(resultInterpreter));
        }
    }
}
