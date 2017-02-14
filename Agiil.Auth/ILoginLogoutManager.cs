using System;
namespace Agiil.Auth
{
  public interface ILoginLogoutManager
  {
    LoginResult AttemptLogin(ILoginRequest request);

    LogoutResult AttemptLogout();
  }
}
