using System;
using Agiil.Web.Services.Auth;
using Autofac;

namespace Agiil.Web.Bootstrap
{
  public class OAuthApplicationConnectionModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<AutofacOAuthApplicationConnection>()
        .As<IOAuthApplicationConnection>();
    }
  }
}
