using System;
using Agiil.Auth;
using Agiil.Web.Services.Auth;
using Autofac;

namespace Agiil.Web.Bootstrap
{
  public class BrakePedalPolicyModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<PermissiveBrakePedalThrottlePolicyProvider>()
        .AsSelf()
        .As<BrakePedalThrottlePolicyProvider>()
        .SingleInstance();
    }
  }
}
