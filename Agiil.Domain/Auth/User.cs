using System;
using CSF.Entities;
using Agiil.Auth;

namespace Agiil.Domain.Auth
{
  public class User : Entity<long>
  {
    public virtual string Username {
      get;
      set;
    }

    public virtual string SerializedCredentials {
      get;
      set;
    }
  }
}
