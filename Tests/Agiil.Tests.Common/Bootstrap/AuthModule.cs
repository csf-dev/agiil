using System;
using Autofac;
using Agiil.Tests.Auth;

namespace Agiil.Tests.Bootstrap
{
  public class AuthModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<InMemoryUserAccountController>().As<IUserAccountController>();
      builder.RegisterType<LoginController>().As<ILoginController>();
    }
  }
}
