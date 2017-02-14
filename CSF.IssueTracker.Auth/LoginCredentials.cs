using System;
using CSF.Security;

namespace CSF.IssueTracker.Auth
{
  public class LoginCredentials : ICredentialsWithPassword
  {
    #region methods

    public string Username { get; set; }

    public string Password { get; set; }

    #endregion

    #region methods

    public byte [] GetPasswordAsByteArray ()
    {
      if(Password == null)
      {
        return null;
      }

      return System.Text.Encoding.UTF8.GetBytes(Password);
    }

    #endregion

    #region constructor

    public LoginCredentials (string username, string password)
    {
      Username = username;
      Password = password;
    }

    #endregion
  }
}
