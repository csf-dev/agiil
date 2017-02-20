﻿using System;
namespace CSF.IssueTracker.Auth
{
  public class LoginResult
  {
    readonly ICurrentUserInfo currentUser;
    static readonly LoginResult loginFailed;

    public bool Success => currentUser != null;

    public LoginResult (ICurrentUserInfo currentUser)
    {
      if (currentUser == null) {
        throw new ArgumentNullException (nameof (currentUser));
      }

      this.currentUser = currentUser;
    }

    LoginResult ()
    {
      currentUser = null;
    }

    static LoginResult()
    {
      loginFailed = new LoginResult();
    }

    public static LoginResult LoginFailed => loginFailed;
  }
}
