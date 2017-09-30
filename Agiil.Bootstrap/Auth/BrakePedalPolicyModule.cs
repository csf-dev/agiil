using System;
using Agiil.Auth;
using Autofac;

namespace Agiil.Bootstrap.Auth
{
  public class BrakePedalPolicyModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .Register(GetPolicy)
        .SingleInstance();
    }

    BrakePedal.IThrottlePolicy GetPolicy(IComponentContext ctx)
    {
      var provider = ctx.Resolve<BrakePedalThrottlePolicyProvider>();
      return provider.GetThrottlePolicy();
    }
  }
}
