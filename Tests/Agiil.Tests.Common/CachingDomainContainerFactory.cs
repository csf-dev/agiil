using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Agiil.Bootstrap;
using Autofac;

namespace Agiil.Tests
{
    public class CachingDomainContainerFactory : DomainContainerFactory
    {
        readonly object syncRoot;
        IContainer container;

        protected override IEnumerable<Assembly> GetModuleAssemblies()
        {
            return base.GetModuleAssemblies().Union(new[] { Assembly.GetExecutingAssembly() });
        }

        public override IContainer GetContainer()
        {
            lock(syncRoot)
            {
                if(container == null)
                    container = base.GetContainer();
            }

            return container;
        }

        public CachingDomainContainerFactory()
        {
            syncRoot = new object();
        }

        static CachingDomainContainerFactory()
        {
            Default = new CachingDomainContainerFactory();
        }

        public static IGetsAutofacContainer Default { get; private set; }
    }
}
