using System;
using Autofac;

namespace Agiil.Bootstrap.RegistrationPassOne
{
  [RegistrationOrder(1)]
  public class ObjectMapsModule : Module
  {
		protected override void Load(ContainerBuilder builder)
		{
      BulkRegistrationHelper.Default.RegisterAll<Agiil.ObjectMaps.IMapperConfigurationFactory>(builder);
		}
	}
}
