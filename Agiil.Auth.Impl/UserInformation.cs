using System;
using CSF.Entities;
using Agiil.Domain.Auth;

namespace Agiil.Auth
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
