using System;
using BrakePedal;

namespace Agiil.Auth
{
  public class BrakePedalLoginThrottlingService : ILoginThrottlingService
  {
    readonly BrakePedalThrottlePolicyProvider policyProvider;

    public LoginThrottlingResponse GetThrottlingResponse(ILoginRequest request)
    {
      var key = GetThrottleKey(request);
      if(key == null) return LoginThrottlingResponse.AttemptPermitted;

      var policy = policyProvider.GetThrottlePolicy();
      if(policy == null) return LoginThrottlingResponse.AttemptPermitted;

      var result = policy.Check(key);

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

    public BrakePedalLoginThrottlingService(BrakePedalThrottlePolicyProvider policyProvider)
    {
      if(policyProvider == null)
        throw new ArgumentNullException(nameof(policyProvider));
      this.policyProvider = policyProvider;
    }
  }
}
