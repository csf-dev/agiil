using System;
using System.Web.Mvc;
using Agiil.Web.Services;
using Autofac;
using Autofac.Integration.Mvc;

namespace Agiil.Web.Bootstrap
{
  public class AspNetMvcGlobalFiltersModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterType<LoginStateModelPopulator>()
        .AsActionFilterFor<Controller>()
        .InstancePerRequest();
    }
  }
}
