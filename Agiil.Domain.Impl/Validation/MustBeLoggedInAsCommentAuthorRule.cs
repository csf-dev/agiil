using System;
using Agiil.Domain.Auth;
using Agiil.Domain.Tickets;
using CSF.ORM;
using CSF.Entities;
using CSF.Validation.Rules;

namespace Agiil.Domain.Validation
{
  public class MustBeLoggedInAsCommentAuthorRule : ValueRule<IIdentity<Comment>>
  {
    readonly ICurrentUserReader userReader;
    readonly IEntityData commentRepo;

    protected override RuleOutcome GetValueOutcome(IIdentity<Comment> value)
    {
      if(ReferenceEquals(value, null))
        return Success;

      var comment = commentRepo.Get(value);

      if(ReferenceEquals(comment, null) || ReferenceEquals(comment.User, null))
        return Success;

      var currentUser = userReader.RequireCurrentUser();

      return (currentUser == comment.User)? Success : Failure;
    }

    public MustBeLoggedInAsCommentAuthorRule(ICurrentUserReader userReader,
                                             IEntityData commentRepo)
    {
      if(commentRepo == null)
        throw new ArgumentNullException(nameof(commentRepo));
      if(userReader == null)
        throw new ArgumentNullException(nameof(userReader));
      this.commentRepo = commentRepo;
      this.userReader = userReader;
    }
  }
}
