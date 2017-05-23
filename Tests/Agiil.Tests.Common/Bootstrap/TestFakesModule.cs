using System;
using Agiil.Auth;
using Autofac;
using Microsoft.Owin.Security;
using Ploeh.AutoFixture;

namespace Agiil.Tests.Bootstrap
{
  public class TestFakesModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<Fixture>().As<IFixture>();

      builder.Register(ctx => new FakeAuthenticationManager()).As<IAuthenticationManager>();
    }
  }
}
