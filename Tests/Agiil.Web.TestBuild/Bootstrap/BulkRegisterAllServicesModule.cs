using Agiil.Web.Services;
using Autofac;

namespace Agiil.Web.Bootstrap
{
    public class BulkRegisterAllServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(IServicesNamespaceMarker).Assembly)
                .AsSelf()
                .AsImplementedInterfaces()
                .PreserveExistingDefaults();
        }
    }
}
