using System;
using CSF.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Agiil.Auth
{
  public class UserLoginLogoutService : ILogsUserInOrOut
  {
    readonly IAuthenticationManager authenticationManager;
    readonly IClaimsIdentityFactory claimsIdentityFactory;

    public void LogUserIn(IAuthenticationResult result) => LogUserIn(result.Username, result.UserIdentity);

    public void LogUserIn(string username, IIdentity userIdentity)
    {
      var identity = claimsIdentityFactory.GetIdentity(username,
                                                       userIdentity,
                                                       DefaultAuthenticationTypes.ApplicationCookie);

      authenticationManager.SignIn(new AuthenticationProperties() {
        AllowRefresh = true,
        IsPersistent = true,
      }, identity);
    }

    public void LogUserOut()
    {
      authenticationManager.SignOut();
    }

    public UserLoginLogoutService(IAuthenticationManager authenticationManager,
                                  IClaimsIdentityFactory claimsIdentityFactory)
    {
      if(claimsIdentityFactory == null)
        throw new ArgumentNullException(nameof(claimsIdentityFactory));
      if(authenticationManager == null)
        throw new ArgumentNullException(nameof(authenticationManager));

      this.claimsIdentityFactory = claimsIdentityFactory;
      this.authenticationManager = authenticationManager;
    }
  }
}
