using System;
using CSF.Security.Authentication;

namespace Agiil.Auth
{
  public class AuthenticationService : CSF.Security.Authentication.PasswordAuthenticationService<AuthenticationRequest>
  {
    public AuthenticationService(IStoredCredentialsRepository repo) : base(repo) {}

    public override IAuthenticationResult GetCannotFindCredentialsResult(AuthenticationRequest request)
    {
      return AuthenticationResult.UserNotFound;
    }

    public override IAuthenticationResult GetCannotCreateVerifierResult(AuthenticationRequest request)
    {
      var userInfo = request?.StoredCredentials?.UserInformation;

      return new AuthenticationResult(userInfo?.Identity, userInfo?.Username, false);
    }

    public override IAuthenticationResult GetVerificationResult(AuthenticationRequest request)
    {
      var userInfo = request?.StoredCredentials?.UserInformation;

      return new AuthenticationResult(userInfo?.Identity, userInfo?.Username, request.PasswordVerified);
    }
  }
}
