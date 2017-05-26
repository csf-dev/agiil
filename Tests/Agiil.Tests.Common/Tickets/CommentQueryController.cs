using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;
using Agiil.Web.Models.Tickets;
using CSF.Data.Entities;
using CSF.Data.NHibernate;
using CSF.Entities;
using NUnit.Framework;

namespace Agiil.Tests.Tickets
{
  public class CommentQueryController : ICommentQueryController
  {
    readonly IRepository<Comment> commentRepository;
    readonly TicketDetailModelContext ticketDetailContext;

    public bool DoesCommentExist(CommentSearchCriteria criteria = null)
    {
      var predicate = CreateCommentSearchPredicate(criteria);
      return commentRepository.Query().AnyCount(predicate);
    }

    public void VerifyThatCommentsAreListedInOrder(IList<CommentDto> expected)
    {
      var actual = ticketDetailContext.Model.Ticket.Comments;
      CollectionAssert.AreEqual(expected, actual, new CommentDtoComparer());
    }

    Expression<Func<Comment,bool>> CreateCommentSearchPredicate(CommentSearchCriteria helper)
    {
      if(helper == null)
        return c => true;

      return c => (((helper.Author == null) || c.User != null && c.User.Username == helper.Author.Trim())
                   && ((helper.Body == null) || c.Body == helper.Body.Trim())
                   && (!helper.TicketId.HasValue || (c.Ticket != null && Equals(c.Ticket.GetIdentity().Value, helper.TicketId.Value)))
                   && (!helper.Id.HasValue || (Equals(c.GetIdentity().Value, helper.Id.Value))));

    }

    public CommentQueryController(IRepository<Comment> commentRepository,
                                  TicketDetailModelContext ticketDetailContext)
    {
      if(ticketDetailContext == null)
        throw new ArgumentNullException(nameof(ticketDetailContext));
      if(commentRepository == null)
        throw new ArgumentNullException(nameof(commentRepository));
      this.commentRepository = commentRepository;
      this.ticketDetailContext = ticketDetailContext;
    }
  }
}
