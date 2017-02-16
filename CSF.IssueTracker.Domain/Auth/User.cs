using System;
using CSF.Entities;
using CSF.IssueTracker.Auth;

namespace CSF.IssueTracker.Domain.Auth
{
  public class User : Entity<long>, IAuthenticationInfoProvider
  {
    public virtual Organisation Organisation
    {
      get;
      set;
    }

    public virtual string Username {
      get;
      set;
    }

    public virtual string AuthenticationInfo {
      get;
      set;
    }

    string IAuthenticationInfoProvider.GetAuthenticationInfo ()
    {
      return AuthenticationInfo;
    }
  }
}
