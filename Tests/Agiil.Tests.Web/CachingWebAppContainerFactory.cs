using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Agiil.Bootstrap;
using Agiil.Web.App_Start;
using Autofac;

namespace Agiil.Tests
{
    public class CachingWebAppContainerFactory : WebAppContainerFactory
    {
        static readonly IGetsAutofacContainer defaultInstance;

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

        public CachingWebAppContainerFactory()
        {
            syncRoot = new object();
        }

        static CachingWebAppContainerFactory()
        {
            defaultInstance = new CachingWebAppContainerFactory();
        }

        public static IGetsAutofacContainer Default => defaultInstance;
    }
}
