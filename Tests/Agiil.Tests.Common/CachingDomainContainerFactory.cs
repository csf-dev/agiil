using Agiil.Bootstrap;
using Autofac;

namespace Agiil.Tests
{
    public class CachingDomainContainerFactory : IGetsAutofacContainer, IGetsAutofacContainerBuilder
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

        public CachingDomainContainerFactory()
        {
            syncRoot = new object();
            builderProvider = new DomainContainerFactory();
        }

        static CachingDomainContainerFactory()
        {
            Default = new CachingDomainContainerFactory();
        }

        public static IGetsAutofacContainer Default { get; private set; }
    }
}
