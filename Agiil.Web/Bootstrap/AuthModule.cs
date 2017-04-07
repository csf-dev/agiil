using System;
using System.Web;
using Agiil.Auth;
using Agiil.Web.Services.Auth;
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

      //builder.RegisterType<OAuthAuthorizationServerMiddleware>();

      builder.RegisterType<OAuthAuthorizationProvider>();

      builder.RegisterType<OAuthOptionsFactory>();

      builder.Register(ctx => {
        var factory = ctx.Resolve<OAuthOptionsFactory>();
        return factory.GetOptions();
      });
    }
  }
}
