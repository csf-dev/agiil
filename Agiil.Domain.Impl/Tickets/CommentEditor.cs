using System;
using Agiil.Domain.Validation;
using CSF.ORM;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public class CommentEditor : ICommentEditor
  {
    readonly ICreatesValidators<EditCommentRequest> validatorFactory;
    readonly Func<IValidationResult, EditCommentResponse> responseCreator;
    readonly IGetsTransaction transactionCreator;
    readonly IEntityData commentRepo;
    readonly IEnvironment environment;

    public EditCommentResponse Edit(EditCommentRequest request)
    {
      var validator = validatorFactory.GetValidator();
      var validationResult = validator.Validate(request);

      if(!validationResult.IsSuccess)
        return responseCreator(validationResult);

      using(var tran = transactionCreator.GetTransaction())
      {
        var comment = commentRepo.Get(request.CommentIdentity);
        comment.Body = request.Body;
        comment.LastEditTimestamp = environment.GetCurrentUtcTimestamp();
        commentRepo.Update(comment);
        tran.Commit();
      }

      return responseCreator(validationResult);
    }

    public CommentEditor(ICreatesValidators<EditCommentRequest> validatorFactory,
                         Func<IValidationResult, EditCommentResponse> responseCreator,
                         IGetsTransaction transactionCreator,
                         IEntityData commentRepo,
                         IEnvironment environment)
    {
      if(environment == null)
        throw new ArgumentNullException(nameof(environment));
      if(commentRepo == null)
        throw new ArgumentNullException(nameof(commentRepo));
      if(transactionCreator == null)
        throw new ArgumentNullException(nameof(transactionCreator));
      if(responseCreator == null)
        throw new ArgumentNullException(nameof(responseCreator));
      if(validatorFactory == null)
        throw new ArgumentNullException(nameof(validatorFactory));
      this.validatorFactory = validatorFactory;
      this.responseCreator = responseCreator;
      this.transactionCreator = transactionCreator;
      this.commentRepo = commentRepo;
      this.environment = environment;
    }
  }
}
