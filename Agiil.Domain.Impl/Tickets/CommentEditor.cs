using System;
using Agiil.Domain.Validation;
using CSF.Data;
using CSF.Data.Entities;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public class CommentEditor : ICommentEditor
  {
    readonly IValidatorFactory<EditCommentRequest> validatorFactory;
    readonly Func<IValidationResult, EditCommentResponse> responseCreator;
    readonly ITransactionCreator transactionCreator;
    readonly IRepository<Comment> commentRepo;
    readonly IEnvironment environment;

    public EditCommentResponse Edit(EditCommentRequest request)
    {
      var validator = validatorFactory.GetValidator();
      var validationResult = validator.Validate(request);

      if(!validationResult.IsSuccess)
        return responseCreator(validationResult);

      using(var tran = transactionCreator.BeginTransaction())
      {
        var comment = commentRepo.Get(request.CommentIdentity);
        comment.Body = request.Body;
        comment.LastEditTimestamp = environment.GetCurrentUtcTimestamp();
        commentRepo.Update(comment);
        tran.Commit();
      }

      return responseCreator(validationResult);
    }

    public CommentEditor(IValidatorFactory<EditCommentRequest> validatorFactory,
                         Func<IValidationResult, EditCommentResponse> responseCreator,
                         ITransactionCreator transactionCreator,
                         IRepository<Comment> commentRepo,
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
