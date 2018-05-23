﻿using System;
using Agiil.Web.Services;
using Agiil.Web.Services.Auth;
using Agiil.Web.Services.Data;
using Autofac;

namespace Agiil.Web.Bootstrap
{
  public class ServicesModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<LoginStateReader>();
      builder.RegisterType<VersionInfoProvider>().AsSelf().AsImplementedInterfaces();
      builder
        .Register(c => ApplicationBaseUriProvider.CreateFromHttpContext())
        .AsSelf()
        .AsImplementedInterfaces();
      builder
        .RegisterType<AppSettingsDatabaseMaintenanceSecurityProvider>()
        .AsImplementedInterfaces();
    }
  }
}
