using System;
using System.Linq;
using System.Security.Claims;
using CSF.Data;
using CSF.Entities;
using Agiil.Domain.Auth;
using CSF.Security.Authentication;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;

namespace Agiil.Auth
{
  public class LoginLogoutManager : ILoginLogoutManager
  {
    #region fields

    readonly IPasswordAuthenticationService authenticationService;
    readonly ILogsUserInOrOut loginLogoutService;
    readonly ILoginThrottlingService throttlingService;

    #endregion

    #region properties

    protected IPasswordAuthenticationService AuthenticationService => authenticationService;

    #endregion

    #region methods

    public virtual LoginResult AttemptLogin(ILoginRequest request)
    {
      if(request == null)
        throw new ArgumentNullException(nameof(request));
      
      var result = (AuthenticationResult) AuthenticationService.Authenticate(request.GetCredentials());

      if(!result.Success)
      {
        return LoginResult.LoginFailed;
      }

      var currentUser = LogUserIn(request, result);
      return new LoginResult(currentUser.Username);
    }

    public virtual LogoutResult AttemptLogout()
    {
      loginLogoutService.LogUserOut();
      return LogoutResult.LogoutSuccessful;
    }

    protected virtual ICurrentUserInfo LogUserIn(ILoginRequest request, AuthenticationResult result)
    {
      loginLogoutService.LogUserIn(result);
      return new UserInformation(result.UserIdentity, result.Username);
    }

    #endregion

    #region constructor

    public LoginLogoutManager(IPasswordAuthenticationService authenticationService,
                              ILogsUserInOrOut loginLogoutService,
                              ILoginThrottlingService throttlingService)
    {
      if(loginLogoutService == null)
        throw new ArgumentNullException(nameof(loginLogoutService));
      if(throttlingService == null)
        throw new ArgumentNullException(nameof(throttlingService));
      if(authenticationService == null)
        throw new ArgumentNullException(nameof(authenticationService));
      
      this.authenticationService = authenticationService;
      this.loginLogoutService = loginLogoutService;
      this.throttlingService = throttlingService;
    }

    #endregion
  }
}
