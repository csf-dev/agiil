using System;
using System.Collections.Generic;
using Agiil.Web.Services;
using Agiil.Web.Services.Auth;
using Agiil.Web.Services.Data;
using Agiil.Web.Services.Labels;
using Agiil.Web.Services.Rendering;
using Autofac;

namespace Agiil.Web.Bootstrap
{
  public class ServicesModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<LoginStateReader>();
      builder.RegisterType<VersionInfoProvider>().AsSelf().AsImplementedInterfaces();
      builder.RegisterType<RenderingTicketUriProviderAdapter>().AsSelf().AsImplementedInterfaces();
      builder
        .RegisterType<ApplicationBaseUriProvider>()
        .AsSelf()
        .AsImplementedInterfaces();
      builder
        .RegisterType<AppSettingsDatabaseMaintenanceSecurityProvider>()
        .AsImplementedInterfaces();
      builder.RegisterType<LabelDetailProvider>().AsSelf().AsImplementedInterfaces();
    }
  }
}
