using System;
using Autofac;
using Agiil.Tests.Auth;

namespace Agiil.Tests.Bootstrap
{
  public class AuthModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<UserAccountController>().As<IUserAccountController>();
      builder.RegisterType<LoginController>().As<ILoginController>();
    }
  }
}
