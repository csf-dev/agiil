using System;
using Autofac;

namespace Agiil.Bootstrap.RegistrationPassOne
{
  [RegistrationOrder(1)]
  public class AuthenticationModule : Module
  {
		protected override void Load(ContainerBuilder builder)
		{
      BulkRegistrationHelper.Default.RegisterAll<Agiil.Auth.AuthenticationAssemblyMarker>(builder);
		}
	}
}
