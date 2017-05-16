using System;
using CSF.Data;
using CSF.Data.Entities;

namespace Agiil.Domain.Tickets
{
  public class CommentCreator : ICommentCreator
  {
    readonly IRepository<Ticket> ticketRepo;
    readonly ICommentFactory commentFactory;
    readonly ITransactionCreator transactionCreator;

    public CreateCommentResponse Create(CreateCommentRequest request)
    {
      // TODO: Validate the request
      // TODO: Exit the method early if it's not valid

      using(var tran = transactionCreator.BeginTransaction())
      {
        var ticket = ticketRepo.Get(request.TicketId);
        var comment = commentFactory.Create(request.Body);
        ticket.Comments.Add(comment);

        ticketRepo.Update(ticket);

        tran.Commit();
      }

      return new CreateCommentResponse { IsSuccess = true };
    }

    public CommentCreator(IRepository<Ticket> ticketRepo,
                          ICommentFactory commentFactory,
                          ITransactionCreator transactionCreator)
    {
      if(transactionCreator == null)
        throw new ArgumentNullException(nameof(transactionCreator));
      if(commentFactory == null)
        throw new ArgumentNullException(nameof(commentFactory));
      if(ticketRepo == null)
        throw new ArgumentNullException(nameof(ticketRepo));
      this.commentFactory = commentFactory;
      this.ticketRepo = ticketRepo;
      this.transactionCreator = transactionCreator;
    }
  }
}
