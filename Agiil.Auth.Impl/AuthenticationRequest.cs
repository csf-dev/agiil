using System;
using CSF.Security.Authentication;

namespace Agiil.Auth
{
  public class AuthenticationRequest : PasswordAuthenticationRequest<LoginCredentials,StoredUserInformation,AuthenticationResult>
  {
  }
}
