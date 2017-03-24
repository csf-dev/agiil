using System;
using Agiil.Domain.Auth;
using CSF.Entities;

namespace Agiil.Auth
{
  public class AuthenticationResult : CSF.Security.Authentication.AuthenticationResult, IAuthenticationResult
  {
    static AuthenticationResult userNotFound;

    public string Username { get; private set; }

    public IIdentity<User> UserIdentity { get; private set; }

    IIdentity IAuthenticationResult.UserIdentity => UserIdentity;

    private AuthenticationResult(bool success, bool credentialsFound) : base(success, credentialsFound) {}

    public AuthenticationResult(IIdentity<User> userIdentity, string username, bool success) : base(success, true)
    {
      Username = username;
      UserIdentity = userIdentity;
    }

    static AuthenticationResult()
    {
      userNotFound = new AuthenticationResult(false, false);
    }

    public static AuthenticationResult UserNotFound => userNotFound;
  }
}
