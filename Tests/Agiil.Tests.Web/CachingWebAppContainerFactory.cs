using Agiil.Bootstrap;
using Agiil.Web.App_Start;
using Autofac;

namespace Agiil.Tests
{
    public class CachingWebAppContainerFactory : IGetsAutofacContainer, IGetsAutofacContainerBuilder
    {
        readonly object syncRoot;
        readonly IGetsAutofacContainerBuilder builderProvider;
        IContainer container;

        public IContainer GetContainer()
        {
            lock(syncRoot)
            {
                if(container == null)
                {
                    var containerFactory = new AutofacContainerCreator(this);
                    container = containerFactory.GetContainer();
                }
            }

            return container;
        }

        public ContainerBuilder GetContainerBuilder()
        {
            var builder = builderProvider.GetContainerBuilder();
            builder.RegisterAssemblyModules(GetType().Assembly);
            return builder;
        }

        public CachingWebAppContainerFactory()
        {
            syncRoot = new object();
            builderProvider = new WebAppContainerFactory();
        }

        static CachingWebAppContainerFactory()
        {
            Default = new CachingWebAppContainerFactory();
        }

        public static IGetsAutofacContainer Default { get; private set; }
    }
}
