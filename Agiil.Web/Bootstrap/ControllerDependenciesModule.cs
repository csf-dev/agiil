using System;
using Agiil.Web.Controllers;
using Autofac;

namespace Agiil.Web.Bootstrap
{
  public class ControllerDependenciesModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<ControllerBaseDependencies>();
    }
  }
}
