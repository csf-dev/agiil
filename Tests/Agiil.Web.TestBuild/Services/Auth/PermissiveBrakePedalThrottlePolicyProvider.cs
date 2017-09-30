using System;
using Agiil.Auth;
using BrakePedal;

namespace Agiil.Web.Services.Auth
{
  public class PermissiveBrakePedalThrottlePolicyProvider : BrakePedalThrottlePolicyProvider
  {
    public override IThrottlePolicy GetThrottlePolicy()
    {
      return new ThrottlePolicy
      {
        Name = PolicyName,
        Prefixes = new [] { Prefix },
        Limiters = new [] {
          new Limiter().Limit(5).PerSecond(1)
          },
      };
    }
  }
}
