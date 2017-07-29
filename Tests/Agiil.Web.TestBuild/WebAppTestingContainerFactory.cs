using System;
using Autofac;
using Agiil.Web.App_Start;
using System.Reflection;

namespace Agiil.Web.TestBuild
{
  public class WebAppTestingContainerFactory : WebAppContainerFactory
  {
    public override IContainer GetContainer()
    {
      var container = base.GetContainer();

      ApplicationContainer.Current = container;

      return container;
    }

    public override ContainerBuilder GetContainerBuilder()
    {
      var builder = base.GetContainerBuilder();

      RegisterComponentsWhichAreOverridenInTheTestingBuild(builder);

      return builder;
    }

    protected virtual void RegisterComponentsWhichAreOverridenInTheTestingBuild(ContainerBuilder builder)
    {
      builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
    }
  }
}
