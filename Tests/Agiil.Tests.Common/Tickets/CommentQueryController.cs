using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Agiil.Domain.Tickets;
using Agiil.Web.Models;
using CSF.Data.Entities;
using CSF.Data.NHibernate;
using CSF.Entities;

namespace Agiil.Tests.Tickets
{
  public class CommentQueryController : ICommentQueryController
  {
    readonly IRepository<Comment> commentRepository;

    public bool DoesCommentExist(CommentSearchCriteria criteria = null)
    {
      var predicate = CreateCommentSearchPredicate(criteria);
      return commentRepository.Query().AnyCount(predicate);
    }

    public void VerifyThatCommentsAreListedInOrder(IList<CommentDto> expected)
    {
      throw new NotImplementedException();
    }

    Expression<Func<Comment,bool>> CreateCommentSearchPredicate(CommentSearchCriteria helper)
    {
      if(helper == null)
        return c => true;

      return c => ((String.IsNullOrWhiteSpace(helper.Author) || c.User != null && c.User.Username == helper.Author.Trim())
                   && (String.IsNullOrWhiteSpace(helper.Body) || c.Body == helper.Body.Trim())
                   && (!helper.TicketId.HasValue || (c.Ticket != null && Equals(c.Ticket.GetIdentity().Value, helper.TicketId.Value))));

    }

    public CommentQueryController(IRepository<Comment> commentRepository)
    {
      if(commentRepository == null)
        throw new ArgumentNullException(nameof(commentRepository));
      this.commentRepository = commentRepository;
    }
  }
}
