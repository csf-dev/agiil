using System;
using Agiil.Domain.Auth;

namespace Agiil.Domain.Tickets
{
  public class CommentFactory : ICommentFactory
  {
    readonly ICurrentUserReader currentUserReader;
    readonly IEnvironment environment;

    public Comment Create(string body)
    {
      var user = currentUserReader.RequireCurrentUser();
      var now = environment.GetCurrentUtcTimestamp();

      return new Comment
      {
        CreationTimestamp = now,
        LastEditTimestamp = now,
        User = user,
        Body = body,
      };
    }

    public CommentFactory(ICurrentUserReader currentUserReader,
                          IEnvironment environment)
    {
      if(environment == null)
        throw new ArgumentNullException(nameof(environment));
      if(currentUserReader == null)
        throw new ArgumentNullException(nameof(currentUserReader));
      this.currentUserReader = currentUserReader;
      this.environment = environment;
    }
  }
}
