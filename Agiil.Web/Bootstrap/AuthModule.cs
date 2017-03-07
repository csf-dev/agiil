using System;
using Agiil.Auth;
using Agiil.Web.Services.Auth;
using Autofac;

namespace Agiil.Web.Bootstrap
{
  public class AuthModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<HttpContextClaimsPrincipalIdentityReader>()
        .As<IIdentityReader>();
    }
  }
}
