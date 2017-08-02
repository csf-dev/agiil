using System;
using Autofac;
using Agiil.Web.App_Start;
using System.Reflection;
using System.Collections.Generic;
using Agiil.Web.Bootstrap;
using Agiil.Web.TestBuild.Bootstrap;
using System.Linq;

namespace Agiil.Web.TestBuild.App_Start
{
  public class WebAppTestingContainerFactory : WebAppContainerFactory
  {
    protected override IEnumerable<Assembly> GetAssembliesToAutoscan()
    {
      return base.GetAssembliesToAutoscan()
        .Union(new [] { Assembly.GetExecutingAssembly() })
        .ToArray();
    }

    protected override IEnumerable<Type> GetModuleTypesNotToRegisterAutomatically()
    {
      return base.GetModuleTypesNotToRegisterAutomatically()
        .Union(new [] { typeof(AspNetWebApiTestBuildModule) })
        .ToArray();
    }

    protected override void RegisterAspNetWebApiComponents(ContainerBuilder builder)
    {
      builder.RegisterModule(new AspNetWebApiTestBuildModule(HttpConfig));
    }
  }
}
