using System;
using Agiil.Bootstrap;
using Agiil.Web.App_Start;
using Agiil.Web.OAuth;
using Autofac;

namespace Agiil.Web.Bootstrap
{
  public class OAuthModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<AutofacOAuthApplicationConnection>()
        .As<IOAuthApplicationConnection>();

      builder
        .RegisterType<OAuthAuthorizationProvider>();

      builder
        .RegisterType<OAuthAuthorizationChecker>()
        .AsSelf()
        .As<IOAuthAuthorizationChecker>();

      builder
        .RegisterType<OAuthOptionsFactory>();

      builder
        .RegisterType<OAuthJwtFormat>();

      builder.Register(ctx => {
        var factory = ctx.Resolve<OAuthOptionsFactory>();
        return factory.GetOptions();
      });

      builder
        .RegisterConfiguration<OAuthConfigurationSection>()
        .As<IOAuthConfiguration>();

      builder
        .RegisterType<RouteConfiguration>()
        .As<IOAuthPathProvider>();

      builder
        .RegisterType<JwtBearerAuthenticationOptionsFactory>()
        .As<IJwtBearerAuthenticationOptionsFactory>();
    }
  }
}
