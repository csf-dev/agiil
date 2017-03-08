using System;
using System.Linq;
using System.Security.Claims;
using CSF.Data;
using CSF.Entities;
using Agiil.Domain.Auth;
using CSF.Security;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;

namespace Agiil.Auth
{
  public class LoginLogoutManager : ILoginLogoutManager
  {
    #region fields

    readonly IAuthenticationService<LoginCredentials> authenticationService;
    readonly IQuery query;
    readonly IAuthenticationManager authenticationManager;

    #endregion

    #region properties

    protected IAuthenticationManager AuthenticationManager => authenticationManager;

    protected IAuthenticationService<LoginCredentials> AuthenticationService => authenticationService;

    protected IQuery Query => query;

    #endregion

    #region methods

    public virtual LoginResult AttemptLogin(ILoginRequest request)
    {
      if(request == null)
        throw new ArgumentNullException(nameof(request));
      
      var result = AuthenticationService.Authenticate(request.GetCredentials());

      if(!result.CredentialsVerified)
      {
        return LoginResult.LoginFailed;
      }

      var currentUser = LogUserIn(request);
      return new LoginResult(currentUser);
    }

    public virtual LogoutResult AttemptLogout()
    {
      AuthenticationManager.SignOut();
      return LogoutResult.LogoutSuccessful;
    }

    protected virtual ICurrentUserInfo LogUserIn(ILoginRequest request)
    {
      var user = GetUser(request.GetCredentials().Username);
      var identity = CreateIdentity(user);

      AuthenticationManager.SignIn(new AuthenticationProperties() {
        AllowRefresh = true,
        IsPersistent = true,
      }, identity);

      return new UserInformation(user.GetIdentity(), user.Username);
    }

    protected virtual ClaimsIdentity CreateIdentity(User user)
    {
      var claims = new [] {
        new Claim(ClaimTypes.NameIdentifier, user.Username),
        new Claim(CustomClaimTypes.UserNumericId, user.GetIdentity().Value.ToString()),
      };
      return new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
    }

    protected virtual User GetUser(string username)
    {
      return Query.Query<User>()
        .Single(x => x.Username == username);
    }

    #endregion

    #region constructor

    public LoginLogoutManager(IAuthenticationService<LoginCredentials> authenticationService,
                              IQuery query,
                              IAuthenticationManager authenticationManager)
    {
      if(authenticationManager == null)
        throw new ArgumentNullException(nameof(authenticationManager));
      if(query == null)
        throw new ArgumentNullException(nameof(query));
      if(authenticationService == null)
        throw new ArgumentNullException(nameof(authenticationService));
      
      this.authenticationService = authenticationService;
      this.query = query;
      this.authenticationManager = authenticationManager;
    }

    #endregion
  }
}
