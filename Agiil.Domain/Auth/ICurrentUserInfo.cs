using System;
using CSF.Entities;

namespace Agiil.Domain.Auth
{
  public interface ICurrentUserInfo
  {
    IIdentity<User> Identity { get; }

    string Username { get; }
  }
}
