using System;
using Agiil.Domain.Validation;

namespace Agiil.Domain.Projects
{
    public class ValidatingProjectCreatorDecorator : ICreatesProject
    {
        readonly ICreatesProject wrapped;
        readonly ICreatesValidators<CreateProjectRequest> validatorFactory;

        public CreateProjectResponse CreateNewProject(CreateProjectRequest request)
        {
            var validator = validatorFactory.GetValidator();
            var result = validator.Validate(request);

            var output = result.IsSuccess ? wrapped.CreateNewProject(request) : new CreateProjectResponse();
            output.ValidationResult = result;

            return output;
        }

        public ValidatingProjectCreatorDecorator(ICreatesProject wrapped, ICreatesValidators<CreateProjectRequest> validatorFactory)
        {
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
            this.validatorFactory = validatorFactory ?? throw new ArgumentNullException(nameof(validatorFactory));
        }
    }
}
