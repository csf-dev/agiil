using System;
using CSF.Entities;
using CSF.IssueTracker.Domain.Auth;

namespace CSF.IssueTracker.Auth
{
  public class UserInformation : ICurrentUserInfo
  {
    readonly IIdentity<User> identity;
    readonly string username;

    public IIdentity<User> Identity => identity;

    public string Username => username;

    public UserInformation(IIdentity<User> identity, string username)
    {
      if(username == null)
        throw new ArgumentNullException(nameof(username));
      if(identity == null)
        throw new ArgumentNullException(nameof(identity));

      this.identity = identity;
      this.username = username;
    }
  }
}
