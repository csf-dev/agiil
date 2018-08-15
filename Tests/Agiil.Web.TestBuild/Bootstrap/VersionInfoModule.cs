using System;
using Agiil.Web.Services;
using Autofac;

namespace Agiil.Web.Bootstrap
{
  public class VersionInfoModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      RegisterVersionNumberProvider(builder);
    }

    void RegisterVersionNumberProvider(ContainerBuilder builder)
    {
      builder
        .RegisterType<OverridableVersionInfoProvider>()
        .AsSelf()
        .AsImplementedInterfaces()
        .SingleInstance();
    }
  }
}
