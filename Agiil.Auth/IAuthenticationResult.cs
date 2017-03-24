using System;
using CSF.Entities;

namespace Agiil.Auth
{
  public interface IAuthenticationResult : CSF.Security.Authentication.IAuthenticationResult
  {
    string Username { get; }

    IIdentity UserIdentity { get; }
  }
}
