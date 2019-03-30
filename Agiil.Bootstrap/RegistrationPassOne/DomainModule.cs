using System;
using Autofac;

namespace Agiil.Bootstrap.RegistrationPassOne
{
  [RegistrationOrder(1)]
  public class DomainModule : Module
  {
		protected override void Load(ContainerBuilder builder)
		{
      BulkRegistrationHelper.Default.RegisterAll<Domain.DomainAssemblyMarker>(builder);
		}
	}
}
