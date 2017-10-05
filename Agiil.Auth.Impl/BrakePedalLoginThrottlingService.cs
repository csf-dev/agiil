using System;
using BrakePedal;

namespace Agiil.Auth
{
  public class BrakePedalLoginThrottlingService : ILoginThrottlingService
  {
    readonly IThrottlePolicy throttlePolicy;

    public LoginThrottlingResponse GetThrottlingResponse(ILoginRequest request)
    {
      var key = GetThrottleKey(request);
      if(key == null) return LoginThrottlingResponse.AttemptPermitted;

      var result = throttlePolicy.Check(key);

      if(result.IsLocked)
        return new LoginThrottlingResponse(result.Limiter.LockDuration.GetValueOrDefault());

      if(result.IsThrottled)
        return new LoginThrottlingResponse(result.Limiter.Period);

      return LoginThrottlingResponse.AttemptPermitted;
    }

    IThrottleKey GetThrottleKey(ILoginRequest request)
    {
      if(request == null) return null;
      if(request.SourceAddress == null) return null;

      return new SimpleThrottleKey(request.SourceAddress);
    }

    public BrakePedalLoginThrottlingService(IThrottlePolicy throttlePolicy)
    {
      if(throttlePolicy == null)
        throw new ArgumentNullException(nameof(throttlePolicy));
      this.throttlePolicy = throttlePolicy;
    }
  }
}
