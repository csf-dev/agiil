using System;
using Agiil.Auth;
using Agiil.BDD.Controllers.Auth;

namespace Agiil.BDD.Auth
{
  public class LoginController : ILoginController
  {
    readonly ILoginLogoutManager loginLogoutManager;
    readonly LoginRequestCreator loginRequestCreator;

    public void Login(string username, string password)
    {
      var loginRequest = loginRequestCreator(username, password);
      loginLogoutManager.AttemptLogin(loginRequest);
    }

    public LoginController (ILoginLogoutManager loginLogoutManager,
                            LoginRequestCreator loginRequestCreator)
    {
      if(loginRequestCreator == null)
        throw new ArgumentNullException(nameof(loginRequestCreator));
      if(loginLogoutManager == null)
        throw new ArgumentNullException(nameof(loginLogoutManager));
      
      this.loginLogoutManager = loginLogoutManager;
      this.loginRequestCreator = loginRequestCreator;
    }
  }
}
