using System;
using CSF.Security;

namespace Agiil.Auth
{
  public class LoginCredentials : ICredentialsWithPassword
  {
    public string Username { get; set; }

    public string Password { get; set; }

    public byte [] GetPasswordAsByteArray ()
    {
      if(Password == null)
      {
        return null;
      }

      return System.Text.Encoding.UTF8.GetBytes(Password);
    }

    public LoginCredentials (string username, string password)
    {
      Username = username;
      Password = password;
    }
  }
}
