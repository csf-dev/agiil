using System;
using Agiil.Web.Services.SharedModel;
using Autofac;

namespace Agiil.Web.Bootstrap
{
  public class SharedModelServicesModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<LoginStateReader>();
      builder.RegisterType<StandardPageModelFactory>();
      builder.RegisterType<StandardPageModelPopulator>();
    }
  }
}
