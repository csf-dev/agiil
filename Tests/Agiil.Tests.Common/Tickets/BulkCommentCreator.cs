using System;
using System.Collections.Generic;
using Agiil.Domain.Auth;
using CSF.Data;
using CSF.Data.Entities;
using System.Linq;
using Agiil.Domain.Tickets;

namespace Agiil.Tests.Tickets
{
  public class BulkCommentCreator : IBulkCommentCreator
  {
    readonly IRepository<Comment> commentRepo;
    readonly IRepository<Ticket> ticketRepo;
    readonly IRepository<User> userRepo;
    readonly ITransactionCreator transactionFactory;
    readonly ICommentFactory commentFactory;

    public void CreateComments(IEnumerable<BulkCommentSpecification> comments)
    {
      if(comments == null)
        throw new ArgumentNullException(nameof(comments));

      using(var trans = transactionFactory.BeginTransaction())
      {
        foreach(var spec in comments)
        {
          var user = userRepo
            .Query()
            .FirstOrDefault(x => x.Username.Equals(spec.Author, StringComparison.InvariantCultureIgnoreCase));
          if(ReferenceEquals(user, null))
            user = userRepo.Query().First();
          var comment = commentFactory.Create(spec.Body);
          comment.CreationTimestamp = spec.Timestamp;
          if(spec.Id.HasValue)
            comment.SetIdentityValue(spec.Id.Value);

          var ticket = ticketRepo.Get(spec.TicketIdentity);
          ticket.Comments.Add(comment);

          ticketRepo.Update(ticket);
          commentRepo.Add(comment);
        }

        trans.Commit();
      }
    }

    public BulkCommentCreator(IRepository<Comment> commentRepo,
                              IRepository<Ticket> ticketRepo,
                              IRepository<User> userRepo,
                              ITransactionCreator transactionFactory,
                              ICommentFactory commentFactory)
    {
      if(commentFactory == null)
        throw new ArgumentNullException(nameof(commentFactory));
      if(transactionFactory == null)
        throw new ArgumentNullException(nameof(transactionFactory));
      if(userRepo == null)
        throw new ArgumentNullException(nameof(userRepo));
      if(ticketRepo == null)
        throw new ArgumentNullException(nameof(ticketRepo));
      if(commentRepo == null)
        throw new ArgumentNullException(nameof(commentRepo));
      
      this.commentRepo = commentRepo;
      this.ticketRepo = ticketRepo;
      this.userRepo = userRepo;
      this.transactionFactory = transactionFactory;
      this.commentFactory = commentFactory;
    }
  }
}
