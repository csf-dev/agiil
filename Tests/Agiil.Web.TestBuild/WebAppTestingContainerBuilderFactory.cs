using System;
using Autofac;
using Agiil.Web.App_Start;
using System.Reflection;

namespace Agiil.Web.TestBuild
{
  public class WebAppTestingContainerBuilderFactory : WebAppContainerBuilderFactory
  {
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
