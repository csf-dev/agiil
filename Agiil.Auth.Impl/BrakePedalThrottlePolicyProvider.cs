using System;
using BrakePedal;

namespace Agiil.Auth
{
  public class BrakePedalThrottlePolicyProvider
  {
    const string
      POLICY_NAME = "Login attempt throttling",
      PREFIX = "login_attempts";

    const int
      MaxAttemptsPerMinute = 6,
      MaxAttemptsBeforeLockout = 15,
      WindowForLockoutMinutes = 5,
      LockoutDurationMinutes = 5;

    protected string PolicyName => POLICY_NAME;

    protected string Prefix => PREFIX;

    public virtual IThrottlePolicy GetThrottlePolicy()
    {
      return new ThrottlePolicy
      {
        Name = PolicyName,
        Prefixes = new [] { Prefix },
        Limiters = new [] {
          GetNonLockingLimiter(),
          GetLockingLimiter(),
        },
      };
    }

    Limiter GetNonLockingLimiter()
    => new Limiter()
      .Limit(MaxAttemptsPerMinute)
      .Over(GetNonLockoutThrottlingDuration());

    Limiter GetLockingLimiter()
    => new Limiter()
      .Limit(MaxAttemptsBeforeLockout)
      .Over(GetLockoutWindow())
      .LockFor(GetLockoutDuration());

    TimeSpan GetLockoutWindow() => TimeSpan.FromMinutes(WindowForLockoutMinutes);

    TimeSpan GetLockoutDuration() => TimeSpan.FromMinutes(LockoutDurationMinutes);

    TimeSpan GetNonLockoutThrottlingDuration() => TimeSpan.FromMinutes(1);
  }
}
