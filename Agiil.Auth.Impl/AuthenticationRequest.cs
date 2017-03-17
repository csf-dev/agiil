using System;

namespace Agiil.Auth
{
  public class AuthenticationRequest : CSF.Security.Authentication.PasswordAuthenticationRequest<LoginCredentials,StoredUserInformation,AuthenticationResult>
  {
  }
}
