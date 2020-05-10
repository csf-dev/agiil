using System;
using Agiil.Domain.Validation;
using CSF.ORM;
using CSF.Validation;

namespace Agiil.Domain.Tickets
{
  public class CommentCreator : ICommentCreator
  {
    readonly IEntityData ticketRepo;
    readonly IEntityData commentRepo;
    readonly ICommentFactory commentFactory;
    readonly IGetsTransaction transactionCreator;
    readonly ICreatesValidators<CreateCommentRequest> validatorFactory;
    readonly Func<IValidationResult, Comment, CreateCommentResponse> responseCreator;

    public CreateCommentResponse Create(CreateCommentRequest request)
    {
      var validator = validatorFactory.GetValidator();
      var validationResult = validator.Validate(request);

      if(!validationResult.IsSuccess)
        return responseCreator(validationResult, null);

      Comment comment;

      using(var tran = transactionCreator.GetTransaction())
      {
        var ticket = ticketRepo.Get(request.TicketId);
        comment = commentFactory.Create(request.Body);
        ticket.Comments.Add(comment);

        ticketRepo.Update(ticket);
        commentRepo.Add(comment);

        tran.Commit();
      }

      return responseCreator(validationResult, comment);
    }

    public CommentCreator(IEntityData ticketRepo,
                          ICommentFactory commentFactory,
                          IGetsTransaction transactionCreator,
                          IEntityData commentRepo,
                          ICreatesValidators<CreateCommentRequest> validatorFactory,
                          Func<IValidationResult,Comment,CreateCommentResponse> responseCreator)
    {
      if(responseCreator == null)
        throw new ArgumentNullException(nameof(responseCreator));
      if(validatorFactory == null)
        throw new ArgumentNullException(nameof(validatorFactory));
      if(commentRepo == null)
        throw new ArgumentNullException(nameof(commentRepo));
      if(transactionCreator == null)
        throw new ArgumentNullException(nameof(transactionCreator));
      if(commentFactory == null)
        throw new ArgumentNullException(nameof(commentFactory));
      if(ticketRepo == null)
        throw new ArgumentNullException(nameof(ticketRepo));
      
      this.validatorFactory = validatorFactory;
      this.commentFactory = commentFactory;
      this.ticketRepo = ticketRepo;
      this.transactionCreator = transactionCreator;
      this.commentRepo = commentRepo;
      this.responseCreator = responseCreator;
    }
  }
}
