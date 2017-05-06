using System;
using Agiil.Auth;
using CSF.Security.Authentication;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace Agiil.Web.Services.Auth
{
  public class OAuthAuthorizationChecker
  {
    #region constants

    const string
      InvalidGrant = "invalid_grant",
      AuthenticationFailureMessage = "The user name or password is incorrect",
      JwtBearerTokenAuthenticationType = "JWT";

    #endregion

    #region fields

    readonly IPasswordAuthenticationService authService;
    readonly LoginRequestCreator loginRequestCreator;
    readonly IClaimsIdentityFactory claimsIdentityFactory;

    #endregion

    #region methods

    public void CheckAuthentication(OAuthGrantResourceOwnerCredentialsContext context)
    {
      var request = loginRequestCreator(context.UserName, context.Password);

      var result = (Agiil.Auth.IAuthenticationResult) authService.Authenticate(request.GetCredentials());

      if(!result.Success)
      {
        context.SetError(InvalidGrant, AuthenticationFailureMessage);
        context.Rejected();
        return;
      }

      var identity = claimsIdentityFactory.GetIdentity(result, JwtBearerTokenAuthenticationType);
      var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
      context.Validated(ticket);
    }

    #endregion

    #region constructor

    public OAuthAuthorizationChecker(IPasswordAuthenticationService authService,
                                     LoginRequestCreator loginRequestCreator,
                                     IClaimsIdentityFactory claimsIdentityFactory)
    {
      if(claimsIdentityFactory == null)
        throw new ArgumentNullException(nameof(claimsIdentityFactory));
      if(loginRequestCreator == null)
        throw new ArgumentNullException(nameof(loginRequestCreator));
      if(authService == null)
        throw new ArgumentNullException(nameof(authService));

      this.authService = authService;
      this.loginRequestCreator = loginRequestCreator;
      this.claimsIdentityFactory = claimsIdentityFactory;
    }

    #endregion
  }
}
