using System;
using Agiil.Domain.Validation;

namespace Agiil.Domain.Projects
{
    public class ValidatingProjectEditorDecorator : IEditsProject
    {
        readonly IEditsProject wrapped;
        readonly ICreatesValidators<EditProjectRequest> validatorFactory;
        readonly Func<EditProjectResponse> responseFactory;

        public EditProjectResponse EditProject(EditProjectRequest request)
        {
            var validator = validatorFactory.GetValidator();
            var result = validator.Validate(request);

            var output = result.IsSuccess ? wrapped.EditProject(request) : responseFactory();
            output.ValidationResult = result;

            return output;
        }

        public ValidatingProjectEditorDecorator(IEditsProject wrapped,
                                                 ICreatesValidators<EditProjectRequest> validatorFactory,
                                                 Func<EditProjectResponse> responseFactory)
        {
            this.wrapped = wrapped ?? throw new ArgumentNullException(nameof(wrapped));
            this.validatorFactory = validatorFactory ?? throw new ArgumentNullException(nameof(validatorFactory));
            this.responseFactory = responseFactory ?? throw new ArgumentNullException(nameof(responseFactory));
        }
    }
}
