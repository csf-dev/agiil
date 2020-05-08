using System;
using Agiil.Domain.Validation;
using CSF.ORM;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public class CommentDeleter : ICommentDeleter
  {
    readonly ICreatesValidators<DeleteCommentRequest> validatorFactory;
    readonly IGetsTransaction transactionCreator;
    readonly IEntityData data;
    readonly Func<IValidationResult, DeleteCommentResponse> responseCreator;

    public DeleteCommentResponse Delete(DeleteCommentRequest request)
    {
      var validator = validatorFactory.GetValidator();
      var validationResult = validator.Validate(request);

      if(!validationResult.IsSuccess)
        return responseCreator(validationResult);

      using(var tran = transactionCreator.GetTransaction())
      {
        var comment = data.Get(request.CommentId);
        comment.Ticket.Comments.Remove(comment);
        tran.Commit();
      }

      return responseCreator(validationResult);
    }

    public CommentDeleter(ICreatesValidators<DeleteCommentRequest> validatorFactory,
                          IGetsTransaction transactionCreator,
                          IEntityData data,
                          Func<IValidationResult, DeleteCommentResponse> responseCreator)
    {
      if(responseCreator == null)
        throw new ArgumentNullException(nameof(responseCreator));
      if(data == null)
        throw new ArgumentNullException(nameof(data));
      if(transactionCreator == null)
        throw new ArgumentNullException(nameof(transactionCreator));
      if(validatorFactory == null)
        throw new ArgumentNullException(nameof(validatorFactory));

      this.validatorFactory = validatorFactory;
      this.transactionCreator = transactionCreator;
      this.data = data;
      this.responseCreator = responseCreator;
    }
  }
}
