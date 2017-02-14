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
    readonly IAuthenticationManager authenticationManager;
    readonly IClaimsIdentityFactory claimsIdentityFactory;

    #endregion

    #region properties

    protected IAuthenticationManager AuthenticationManager => authenticationManager;

    protected IPasswordAuthenticationService AuthenticationService => authenticationService;

    protected IClaimsIdentityFactory ClaimsIdentityFactory => claimsIdentityFactory;

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
      return new LoginResult(currentUser);
    }

    public virtual LogoutResult AttemptLogout()
    {
      AuthenticationManager.SignOut();
      return LogoutResult.LogoutSuccessful;
    }

    protected virtual ICurrentUserInfo LogUserIn(ILoginRequest request, AuthenticationResult result)
    {
      var identity = ClaimsIdentityFactory.GetIdentity(result, DefaultAuthenticationTypes.ApplicationCookie);

      AuthenticationManager.SignIn(new AuthenticationProperties() {
        AllowRefresh = true,
        IsPersistent = true,
      }, identity);

      return new UserInformation(result.UserIdentity, result.Username);
    }

    #endregion

    #region constructor

    public LoginLogoutManager(IPasswordAuthenticationService authenticationService,
                              IAuthenticationManager authenticationManager,
                              IClaimsIdentityFactory claimsIdentityFactory)
    {
      if(claimsIdentityFactory == null)
        throw new ArgumentNullException(nameof(claimsIdentityFactory));
      if(authenticationManager == null)
        throw new ArgumentNullException(nameof(authenticationManager));
      if(authenticationService == null)
        throw new ArgumentNullException(nameof(authenticationService));
      
      this.authenticationService = authenticationService;
      this.authenticationManager = authenticationManager;
      this.claimsIdentityFactory = claimsIdentityFactory;
    }

    #endregion
  }
}
