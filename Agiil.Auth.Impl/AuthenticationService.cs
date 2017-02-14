using System;
using CSF.Security.Authentication;

namespace Agiil.Auth
{
  public class AuthenticationService : CSF.Security.Authentication.PasswordAuthenticationService<AuthenticationRequest>
  {
    public AuthenticationService(IStoredCredentialsRepository repo) : base(repo) {}

    public override CSF.Security.Authentication.IAuthenticationResult GetCannotFindCredentialsResult(AuthenticationRequest request)
    {
      return AuthenticationResult.UserNotFound;
    }

    public override CSF.Security.Authentication.IAuthenticationResult GetCannotCreateVerifierResult(AuthenticationRequest request)
    {
      var userInfo = request?.StoredCredentials?.UserInformation;

      return new AuthenticationResult(userInfo?.Identity, userInfo?.Username, false);
    }

    public override CSF.Security.Authentication.IAuthenticationResult GetVerificationResult(AuthenticationRequest request)
    {
      var userInfo = request?.StoredCredentials?.UserInformation;

      return new AuthenticationResult(userInfo?.Identity, userInfo?.Username, request.PasswordVerified);
    }
  }
}
