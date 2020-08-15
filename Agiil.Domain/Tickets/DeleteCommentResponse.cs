using System;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
    public class DeleteCommentResponse : IIndictesSuccess
    {
        readonly IValidationResult validationResult;

        public bool IsSuccess => validationResult.IsSuccess;

        public DeleteCommentResponse(IValidationResult result)
        {
            this.validationResult = result ?? throw new ArgumentNullException(nameof(result));
        }
    }
}
