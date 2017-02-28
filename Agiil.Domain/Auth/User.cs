using System;
using CSF.Entities;
using Agiil.Auth;

namespace Agiil.Domain.Auth
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
