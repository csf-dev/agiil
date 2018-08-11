using System;
using System.Collections.Generic;
using Agiil.Web.Services;
using Agiil.Web.Services.Auth;
using Agiil.Web.Services.Data;
using Agiil.Web.Services.Labels;
using Agiil.Web.Services.Rendering;
using Autofac;
using Autofac.Core;

namespace Agiil.Web.Bootstrap
{
  public class ServicesModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<LoginStateReader>();
      builder.RegisterType<VersionInfoProvider>().AsSelf().AsImplementedInterfaces();
      builder.RegisterType<TicketUriProvider>().AsSelf().AsImplementedInterfaces();
      builder
        .Register(c => ApplicationBaseUriProvider.CreateFromHttpContext())
        .AsSelf()
        .AsImplementedInterfaces();
      builder
        .RegisterType<AppSettingsDatabaseMaintenanceSecurityProvider>()
        .AsImplementedInterfaces();
      builder.RegisterType<LabelDetailProvider>().AsSelf().AsImplementedInterfaces();
      builder.RegisterType<MvcTempDataProvider>();
      builder.RegisterType<EmptyTempDataProvider>();
      builder.Register(GetTempDataProvider);
    }

    IGetsTempData GetTempDataProvider(IComponentContext ctx, IEnumerable<Parameter> afParams)
    {
      try { return ctx.Resolve<MvcTempDataProvider>(afParams); }
      catch(DependencyResolutionException) { return ctx.Resolve<EmptyTempDataProvider>(); }
    }
  }
}
