using System;
using Autofac;

namespace Agiil.Bootstrap.RegistrationPassOne
{
  [RegistrationOrder(1)]
  public class AuthenticationImplModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      BulkRegistrationHelper.Default.RegisterAll<Agiil.Auth.AuthenticationImplementationAssemblyMarker>(builder);
    }
  }
}
