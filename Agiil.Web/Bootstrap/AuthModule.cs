using System;
using System.Web;
using Agiil.Auth;
using Agiil.Web.Services.Auth;
using Agiil.Web.Services.Config;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin.Security.OAuth;

namespace Agiil.Web.Bootstrap
{
  public class AuthModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<HttpContextPrincipalGetter>()
        .As<IPrincipalGetter>();

      builder.RegisterType<OAuthAuthorizationProvider>();

      builder.RegisterType<OAuthAuthorizationChecker>();

      builder.RegisterType<OAuthOptionsFactory>();

      builder.Register(ctx => {
        var factory = ctx.Resolve<OAuthOptionsFactory>();
        return factory.GetOptions();
      });

      builder
        .RegisterConfiguration<OAuthConfigurationSection>()
        .As<IOAuthConfiguration>();
    }
  }
}
