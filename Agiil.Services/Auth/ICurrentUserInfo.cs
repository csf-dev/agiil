using System;
using Agiil.Domain.Auth;
using CSF.Entities;

namespace Agiil.Services.Auth
{
  public interface ICurrentUserInfo
  {
    IIdentity<User> Identity { get; }

    string Username { get; }
  }
}
