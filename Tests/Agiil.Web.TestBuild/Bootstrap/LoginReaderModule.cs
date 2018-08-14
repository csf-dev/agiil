using System;
using Agiil.Web.Services;
using Autofac;

namespace Agiil.Web.Bootstrap
{
  public class LoginReaderModule : Module
  {
		protected override void Load(ContainerBuilder builder)
		{
      RegisterLoginReader(builder);
		}

		void RegisterLoginReader(ContainerBuilder builder)
    {
      builder
        .RegisterType<OverridableLoginReader>()
        .AsSelf()
        .AsImplementedInterfaces()
        .InstancePerRequest();
    }
  }
}
