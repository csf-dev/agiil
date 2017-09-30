using System;
namespace Agiil.Auth
{
  public class LoginThrottlingResponse
  {
    readonly bool shouldAttemptBeHonoured;
    public virtual bool ShouldAttemptBeHonoured => shouldAttemptBeHonoured;

    readonly TimeSpan? timeUntilNextAttemptPermitted;
    public virtual TimeSpan? TimeUntilNextAttemptPermitted => timeUntilNextAttemptPermitted;

    protected LoginThrottlingResponse()
    {
      shouldAttemptBeHonoured = true;
    }

    public LoginThrottlingResponse(TimeSpan timeUntilNextAttemptPermitted)
    {
      shouldAttemptBeHonoured = false;
      this.timeUntilNextAttemptPermitted = timeUntilNextAttemptPermitted;
    }

    static LoginThrottlingResponse()
    {
      attemptPermitted = new LoginThrottlingResponse();
    }

    readonly static LoginThrottlingResponse attemptPermitted;
    public static LoginThrottlingResponse AttemptPermitted => attemptPermitted;

  }
}
