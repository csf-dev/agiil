using System;
using System.Web.Http;
using Agiil.Web.Services;
using Autofac.Integration.WebApi;

namespace Agiil.Web.Bootstrap
{
    public class AspNetWebApiTestBuildModule : AspNetWebApiModule
    {
        protected override void RegisterControllers(Autofac.ContainerBuilder builder)
        {
            var assemblies = new[] {
                typeof(AspNetWebApiModule).Assembly,
                typeof(IServicesNamespaceMarker).Assembly,
            };

            builder.RegisterApiControllers(assemblies);
        }

        public AspNetWebApiTestBuildModule(HttpConfiguration config) : base(config) { }
    }
}
