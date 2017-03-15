using System;
using CSF.Security.Authentication;

namespace Agiil.Auth
{
  public class LoginCredentials : CredentialsWithPassword
  {
    public string Username { get; set; }
  }
}
