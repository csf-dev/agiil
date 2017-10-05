using System;
namespace Agiil.Auth
{
  public class LoginResult
  {
    #region fields

    readonly string username;
    readonly TimeSpan? timeBeforeNextAttempt;

    #endregion

    #region properties

    public bool Success => username != null;

    public bool Throttled => timeBeforeNextAttempt.HasValue;

    public TimeSpan? TimeBeforeNextAttempt => timeBeforeNextAttempt;

    public string Username => username;

    #endregion

    #region constructors

    public LoginResult (string username)
    {
      if (username == null) {
        throw new ArgumentNullException (nameof (username));
      }

      this.username = username;
    }

    LoginResult(TimeSpan timeBeforeNextAttempt)
    {
      username = null;
      this.timeBeforeNextAttempt = timeBeforeNextAttempt;
    }

    LoginResult() {}

    static LoginResult()
    {
      loginFailed = new LoginResult();
    }

    #endregion

    #region singletons & static factories

    static readonly LoginResult loginFailed;

    public static LoginResult LoginFailed => loginFailed;

    public static LoginResult LoginFailedDueToThrottling(TimeSpan timeBeforeNextAttempt)
      => new LoginResult(timeBeforeNextAttempt);

    #endregion
  }
}
