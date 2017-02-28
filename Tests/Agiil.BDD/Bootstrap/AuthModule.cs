using System;
using Agiil.BDD.Auth;
using Agiil.BDD.Controllers.Auth;
using Agiil.BDD.Impl.Auth;
using Autofac;

namespace Agiil.BDD.Impl.Bootstrap
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
