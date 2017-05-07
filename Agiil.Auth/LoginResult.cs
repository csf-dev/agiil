using System;
namespace Agiil.Auth
{
  public class LoginResult
  {
    readonly string username;
    static readonly LoginResult loginFailed;

    public bool Success => username != null;

    public string Username => username;

    public LoginResult (string username)
    {
      if (username == null) {
        throw new ArgumentNullException (nameof (username));
      }

      this.username = username;
    }

    LoginResult ()
    {
      username = null;
    }

    static LoginResult()
    {
      loginFailed = new LoginResult();
    }

    public static LoginResult LoginFailed => loginFailed;
  }
}
