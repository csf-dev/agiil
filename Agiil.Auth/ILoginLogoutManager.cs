using System;
namespace CSF.IssueTracker.Auth
{
  public interface ILoginLogoutManager
  {
    LoginResult AttemptLogin(ILoginRequest request);

    LogoutResult AttemptLogout();
  }
}
