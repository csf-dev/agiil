using System;
using Autofac;
using System.Reflection;
using System.Collections.Generic;
using Agiil.Web.Bootstrap;
using System.Linq;

namespace Agiil.Web.App_Start
{
    public class WebAppTestingContainerFactory : WebAppContainerFactory
    {
        protected override IEnumerable<Assembly> GetModuleAssemblies()
        {
            return base.GetModuleAssemblies()
              .Union(new[] { Assembly.GetExecutingAssembly(), });
        }

        protected override void RegisterAspNetWebApiComponents(ContainerBuilder builder)
        {
            builder.RegisterModule(new AspNetWebApiTestBuildModule(HttpConfig));
        }
    }
}
