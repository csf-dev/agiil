using System;
using Agiil.Auth;
using Agiil.Domain.Auth;
using Agiil.Web.Models.Shared;

namespace Agiil.Web.Models.Auth
{
  public class LoginModel
  {
    public LoginResult Result { get; set; }

    public virtual LoginCredentials EnteredCredentials { get; set; }

    public string ReturnUrl { get; set; }

    public bool LoginFailed => LoginAttempted && !Result.Success;

    public bool LoginThrottled => LoginAttempted && Result.Throttled;

    public TimeSpan? TimeBeforeNextAttempt => Result.TimeBeforeNextAttempt;

    public bool LoginSucceded => LoginAttempted && Result.Success;

    public bool LoginAttempted => Result != null;

    public string TimeBeforeNextLoginAttempt
    {
      get {
        var time = TimeBeforeNextAttempt;
        if(!time.HasValue) return null;

        if(time.Value.Minutes == 1)
          return $"1 minute";
        else if(time.Value.Minutes > 1)
          return $"{time.Value.Minutes} minutes";

        if(time.Value.Seconds == 1)
          return $"1 second";
        else
          return $"{time.Value.Seconds} seconds";
      }
    }
  }
}
