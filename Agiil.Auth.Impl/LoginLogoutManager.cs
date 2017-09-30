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

    public LoginResult AttemptLogin(ILoginRequest request)
    {
      if(request == null)
        throw new ArgumentNullException(nameof(request));

      LoginResult output = null;
      AuthenticationResult authResult;

      output = GetLoginThrottledResult(request);
      if(output != null) return output;

      output = GetAuthenticationFailedLoginResult(request, out authResult);
      if(output != null) return output;

      var currentUser = LogUserIn(request, authResult);
      return new LoginResult(currentUser.Username);
    }

    public LogoutResult AttemptLogout()
    {
      LogUserOut();
      return LogoutResult.LogoutSuccessful;
    }

    void LogUserOut()
    {
      loginLogoutService.LogUserOut();
    }

    ICurrentUserInfo LogUserIn(ILoginRequest request, AuthenticationResult result)
    {
      loginLogoutService.LogUserIn(result);
      return new UserInformation(result.UserIdentity, result.Username);
    }

    LoginResult GetLoginThrottledResult(ILoginRequest request)
    {
      var throttlingResult = throttlingService.GetThrottlingResponse(request);

      if(throttlingResult == null || throttlingResult.ShouldAttemptBeHonoured) return null;

      var time = throttlingResult.TimeUntilNextAttemptPermitted.GetValueOrDefault();
      return LoginResult.LoginFailedDueToThrottling(time);
    }

    LoginResult GetAuthenticationFailedLoginResult(ILoginRequest request, out AuthenticationResult result)
    {
      result = (AuthenticationResult) AuthenticationService.Authenticate(request.GetCredentials());

      if(result != null && result.Success) return null;
      else return LoginResult.LoginFailed;
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
