using System;
using System.Reflection;
using Agiil.Tests.Common;
using Autofac;

namespace Agiil.BDD
{
  public class BddContainerBuilderFactory : WebControllerContainerBuilderFactory
  {
    protected override void RegisterTestControllerModules(ContainerBuilder builder)
    {
      base.RegisterTestControllerModules(builder);
      builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
    }
  }
}
